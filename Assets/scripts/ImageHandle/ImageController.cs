using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.scripts.ImageHandle
{
    public class ImageController : MonoBehaviour
    {
        public GameObject gameObject;
        public RawImage img;
        public string _urlImg;
        public static ImageController instance;

        // Use this for initialization

        public void setGameObject(GameObject gObj)
        {
            gameObject = gObj;
        }

        public static ImageController GetInstance()
        {
            Debug.Log("GetInstance " + instance);
            return instance;
        }

        public void setUriImage(string uri)
        {
            _urlImg = uri;
        }

        void Awake()
        {
            img = gameObject.GetComponent<RawImage>();
        }

        IEnumerator Start()
        {
            //instance = this;
            Debug.Log("IMG"+ _urlImg);
            WWW www = new WWW(_urlImg);
            yield return www;
            img.texture = www.texture;
        }

        // Update is called once per frame
        //IEnumerator setImageForGameObject()
        //{
        //    Debug.Log(_urlImg);
        //    WWW www = new WWW(_urlImg);
        //    yield return www;
        //    img.texture = www.texture;
        //}
    }
}