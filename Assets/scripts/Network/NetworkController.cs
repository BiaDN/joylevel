using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using System;

namespace scripts.Network 
{
    public class NetworkController : MonoBehaviour
    {
	    public static NetworkController Instance;

	    public void Awake()
	    {
		    Instance = this;
	    }
        public static void sendTestPostAPI() {
			string URL = "";
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(String.Format(URL));
          	HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          	StreamReader reader = new StreamReader(response.GetResponseStream());
          	string jsonResponse = reader.ReadToEnd();
         	Debug.Log("kiiro" + jsonResponse);
		}

		public void callPostAPI(string URL, Dictionary<string, string> inputParams, Action<string> cbSuccess, Action<string> cbFail) {
			callPostAPI(URL, inputParams, null, cbSuccess, cbFail);
		}
		
		public void callPostAPI(string URL, Dictionary<string, string> inputParams,  Dictionary<string, string> headerParams, Action<string> cbSuccess, Action<string> cbFail) {
			WWWForm form = getWWWForm(inputParams);
			StartCoroutine(sendPostIEnumerator(URL, form, headerParams, cbSuccess, cbFail));
		}

		public void callPostAPI(string URL, WWWForm form, Dictionary<string, string> headerParams, Action<string> cbSuccess, Action<string> cbFail) {
			StartCoroutine(sendPostIEnumerator(URL, form, headerParams, cbSuccess, cbFail));
		}

		public void callGetAPI(string URL, Action<string> cbSuccess, Action<string> cbFail)
		{
			callGetAPI(URL, null, cbSuccess, cbFail);
		}
		
		public void callGetAPI(string URL, Dictionary<string, string> headerParams, Action<string> cbSuccess, Action<string> cbFail ) { 			
			StartCoroutine(sendGetIEnumerator(URL, headerParams, cbSuccess, cbFail));
		}
		
		public void callPutAPI(string URL, Dictionary<string, string> headerParams, Dictionary<string, string> inputParams, Action<string> cbSuccess, Action<string> cbFail ) { 			
			WWWForm form = getWWWForm(inputParams);
			StartCoroutine(sendPutIEnumerator(URL, headerParams, form, cbSuccess, cbFail));
		}

		private WWWForm getWWWForm (Dictionary<string, string> inputParams) {
			WWWForm form = new WWWForm();
			foreach (var kvp in inputParams) {
				Debug.Log(kvp.Key + "|" + kvp.Value);
				if (kvp.Key == "" || kvp.Key == null) continue;
	        	form.AddField(kvp.Key, kvp.Value);
			}
			return form;
		}

		private void setHeaderParams(UnityWebRequest www, Dictionary<string, string> headerParams)
		{
			foreach (var kvp in headerParams) {
				Debug.Log(kvp.Key + "|" + kvp.Value);
				if (kvp.Key == "" || kvp.Key == null) continue;
				www.SetRequestHeader(kvp.Key, kvp.Value);
			}
		}

		IEnumerator sendPostIEnumerator(string URL, WWWForm form, Dictionary<string, string> headerParams, Action<string> cbSuccess, Action<string> cbFail) {
        	using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        	{
	            if (headerParams != null)
	            {
		            setHeaderParams(www, headerParams);
	            }
            	yield return www.SendWebRequest();
                handleReceiveAPI(URL, www, cbSuccess, cbFail);
            }
		}

		IEnumerator sendGetIEnumerator(string URL, Dictionary<string, string> headerParams,  Action<string> cbSuccess, Action<string> cbFail) {
        	using (UnityWebRequest www = UnityWebRequest.Get(URL))
        	{
	            if (headerParams != null)
	            {
		            setHeaderParams(www, headerParams);
	            }
	            yield return www.SendWebRequest();
                handleReceiveAPI(URL, www, cbSuccess, cbFail);
            }
		}
		
		IEnumerator sendPutIEnumerator(string URL, Dictionary<string, string> headerParams, WWWForm form,  Action<string> cbSuccess, Action<string> cbFail) {
			using (UnityWebRequest www = UnityWebRequest.Put(URL, form.data))
			{
				if (headerParams != null)
				{
					setHeaderParams(www, headerParams);
				}
				yield return www.SendWebRequest();
				handleReceiveAPI(URL, www, cbSuccess, cbFail);
			}
		}

		private void handleReceiveAPI(string URL, UnityWebRequest www, Action<string> cbSuccess, Action<string> cbFail)
		{
			if (www.result != UnityWebRequest.Result.Success)
			{
				//TODO: alert network fail 
				Debug.Log("[ERROR] sendGetIEnumerator!"+ URL + www.error + " | "+  www.downloadHandler.text);
				cbFail(www.downloadHandler.text);
				return;
			}

			Debug.Log("handleReceiveAPI " + www.downloadHandler.text);
			JObject jsonObject = JObject.Parse(www.downloadHandler.text);
			if ((jsonObject["success"] != null && jsonObject["success"].ToString() != "True") || 
				(jsonObject["statusCode"] != null && int.Parse(jsonObject["statusCode"].ToString()) != 200))
			{
				Debug.Log("[ERROR] sendGetIEnumerator!"+ URL + www.error + " | "+  www.downloadHandler.text);
				cbFail(JObject.Parse(jsonObject["status"].ToString())["error"].ToString());
			}
			else
			{
				Debug.Log("[SUCCESS] sendGetIEnumerator" + jsonObject["data"]);
				cbSuccess(jsonObject["data"].ToString());
			}
		}
    }
}


