using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using scripts.Network;
using Newtonsoft.Json.Linq;
using Assets.scripts.ContainerListCharacter;
using UnityEngine.UI;
using Assets.scripts.ImageHandle;
using UnityEngine.SceneManagement;

namespace Assets.scripts.ListItem
{
    public class ListTeam : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject itemTemplate;
        public GameObject content;
        public GameObject btnDetails;
        public NetworkController networkController;
        public ContainerListCharacter containerListCharacter;

        private void Awake()
        {
            Debug.Log("asasas");
            Dictionary<string, string> myIdUser = new Dictionary<string, string>();
            myIdUser.Add("idUser", "634a39c0c11bc9c06f7dca95");
            string url = NetworkConst.URL_GET_INFO_USER + "?idUser=634a39c0c11bc9c06f7dca95";
            networkController = gameObject.AddComponent<NetworkController>();
            containerListCharacter = gameObject.AddComponent<ContainerListCharacter>();
            networkController.callGetAPI(url, myIdUser, cbAwakeSuccess, cbAwakeFail);
        }

        //void Update()
        //{

        //}
        public void cbAwakeSuccess(string json)
        {
            JObject jsonData = JObject.Parse(json);
            JArray listCharacter = JArray.Parse(jsonData["character"].ToString());
            Debug.Log("cbAwakeSuccess " + listCharacter);
            if (listCharacter.Count == 0)
            {
                GameObject btnCopy = GameObject.Find("BtnCopy");

                btnCopy.GetComponent<Button>().interactable = false;
            }
            for (var i = 0; i < 9; i++)
            {
                //listCharacter.Count
                string name = "TEAM" + " " + (i + 1);
                var copy = Instantiate(itemTemplate);
                GameObject title = copy.transform.GetChild(0).gameObject;
                GameObject txtEmpty = copy.transform.GetChild(2).gameObject;
                GameObject BtnMainteam = copy.transform.GetChild(3).gameObject;

                if (i + 1 <= listCharacter.Count)
                {
                    txtEmpty.SetActive(false);
                    JObject dataCharacter = JObject.Parse(listCharacter[i].ToString());
                    if (jsonData["characterEquipment"].ToString() == dataCharacter["_id"].ToString())
                    {
                        //SpriteMainTeam.GetInstance().updateSprite();
                        SpriteMainTeam.GetInstance().disableButtonSetMainTeam();
                    }
                    SpriteMainTeam.GetInstance().setIdCharacter(dataCharacter["_id"].ToString());
                    string urlImg = dataCharacter["avatar"].ToString();
                    string idCharacter = dataCharacter["_id"].ToString();

                    string txtNameCharacter = dataCharacter["name"].ToString();
                    copy.transform.GetComponent<BtnContainer>().SetIdCharacter(idCharacter);
                    copy.transform.GetComponent<BtnContainer>().SetIdDataCharacter(dataCharacter.ToString());

                    GameObject ContainerDetailCharacter = copy.transform.GetChild(1).gameObject;
                    GameObject btnDetails = GameObject.Find("BtnDetails");
                    GameObject nameCharacter = btnDetails.transform.GetChild(1).gameObject;
                    GameObject imgCharacter = btnDetails.transform.GetChild(0).gameObject;
                    ImageController controllerImg = imgCharacter.GetComponent<ImageController>();
                    controllerImg.setGameObject(imgCharacter);
                    controllerImg.setUriImage(urlImg);
                    nameCharacter.GetComponent<Text>().text = txtNameCharacter;
                    title.GetComponent<Text>().text = name;

                    BtnDetailController btnDetailController = new BtnDetailController();
                    btnDetailController.setTxtNameCharacter(txtNameCharacter);
                    btnDetailController.setGameObjectChild(btnDetails);
                    btnDetailController.setGameObjectParent(ContainerDetailCharacter);
                    btnDetailController.addChildToContent();

                    copy.transform.parent = content.transform;
                }
                else
                {
                    BtnMainteam.SetActive(false);
                    copy.transform.GetChild(1).gameObject.SetActive(false);
                    title.GetComponent<Text>().text = name;
                    copy.transform.parent = content.transform;
                }
            }
        }

        public void cbAwakeFail(string json)
        {
            Debug.Log("cbAwakeFail " + json);
        }
        public void btnCopyOnClick()
        {
            Debug.Log("click");
            var copy = Instantiate(itemTemplate);
            copy.transform.parent = content.transform;
            // itemTemplate.transform.SetParent(content.transform,false);
        }

        public void moveToEditScene(int sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }
    }
}
