using Assets.scripts.ImageHandle;
using Newtonsoft.Json.Linq;
using scripts.Network;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.scripts.EditScreen
{
    public class EditScreenController : MonoBehaviour
    {
        public string dataCharacter;
        public string dataListItemCharacter;
        public JArray dataItemEquimment;

        public NetworkController networkController;
        //public JObject data;
        public GameObject PanelIDetail;
        public GameObject BtnEditItem;
        public GameObject BtnItem;
        public GameObject BtnLock;
        public GameObject panelEditItemCharacter;
        public GameObject LayoutBtnSkillScale;
        public GameObject LayoutEditPositionCharacter;
        public GameObject txtNameCharacter;
        // Use this for initialization
        void hideAllGUI()
        {
            PanelIDetail.SetActive(false);
            //BtnEditItem.SetActive(false);
            //BtnItem.SetActive(false);
            //BtnLock.SetActive(false);
            panelEditItemCharacter.SetActive(false);
            LayoutBtnSkillScale.SetActive(false);
            LayoutEditPositionCharacter.SetActive(false);
            txtNameCharacter.SetActive(false);
        }
        void Awake()
        {
            //PanelIDetail = GameObject.Find("PanelIDetail");
            hideAllGUI();

            networkController = gameObject.AddComponent<NetworkController>();
            //GameObject.Find("LayoutBtnSkillScale").SetActive(false);
            string idCharacter = PlayerPrefs.GetString("idCharacter");
            dataCharacter = PlayerPrefs.GetString("dataCharacter");
            string nameCharacter = JObject.Parse(dataCharacter)["name"].ToString();
            GameObject.Find("InputName").transform.GetChild(0).GetComponent<Text>().text = nameCharacter;
            GameObject.Find("InputName").transform.GetChild(1).GetComponent<Text>().text = nameCharacter;
            GameObject.Find("InputName").GetComponent<InputField>().interactable = false;
            string url = NetworkConst.URL_GET_ALL_ITEM_CHARACTER + "?idCharacter=" + idCharacter;
            networkController.callGetAPI(url, null, cbAwakeSuccess, cbAwakeFail);

            Debug.Log(idCharacter);
        }

        void cbAwakeSuccess(string json)
        {
            PanelIDetail.SetActive(true);
            addStar();
            addPanelHeal();
            addBtnSkillToContainer();
            Debug.Log("[dataCharacter]:" + json);
            dataListItemCharacter = json;
            Debug.Log("START" + dataCharacter);
            JObject data = JObject.Parse(dataCharacter);
            //dataItemEquimment = 
            JArray listDataItem = JArray.Parse(dataListItemCharacter);
            if (data["itemEquipment"] != null)
            {
                dataItemEquimment = JArray.FromObject(listDataItem.Where(items => items["id"].ToString() == data["itemEquipment"].ToString()));
            }
            Debug.Log("dataItemEquimment" + listDataItem);
            Debug.Log("data" + dataItemEquimment);
            GameObject BtnItem = GameObject.Find("BtnItem");

            if (dataItemEquimment != null)
            {
                ImageController controllerImgItem = BtnItem.GetComponent<ImageController>();
                controllerImgItem.setGameObject(BtnItem);
                controllerImgItem.setUriImage(dataItemEquimment[0]["avatar"].ToString());
            }

            panelEditItemCharacter.SetActive(true);

            var BtnItemCopy = Instantiate(BtnItem);
            var BtnItemEditCopy = Instantiate(BtnEditItem);
            var BtnLockCopy = Instantiate(BtnLock);

            //BtnItemCopy.transform.local
            BtnItemCopy.transform.parent = panelEditItemCharacter.transform;
            BtnItemEditCopy.transform.parent = panelEditItemCharacter.transform;
            BtnLockCopy.transform.parent = panelEditItemCharacter.transform;


            //GameObject txtNameCharacter = GameObject.Find("txtNameCharacter");
            GameObject imgCharacter = GameObject.Find("AvtEditScreen");
            ImageController controllerImg = imgCharacter.GetComponent<ImageController>();
            controllerImg.setGameObject(imgCharacter);
            controllerImg.setUriImage(data["avatar"].ToString());
            //txtNameCharacter.GetComponent<Text>().text = data["name"].ToString();
            txtNameCharacter.transform.GetComponent<Text>().text = data["name"].ToString();
            Debug.Log("txtNameCharacter" + data["name"].ToString());
            txtNameCharacter.SetActive(true);
        }

        void addStar()
        {
            GameObject containerStar = GameObject.Find("containerStar");
            GameObject imgStar = GameObject.Find("imgStar");
            for (var i = 0; i < 10; i++)
            {
                var copy = Instantiate(imgStar);
                copy.transform.parent = containerStar.transform;
            }

        }

        void addBtnSkillToContainer()
        {
            GameObject ContainerSkill = GameObject.Find("ContainerSkill");
            GameObject BtnSkill = GameObject.Find("BtnSkill");
            for (var i = 0; i < 4; i++)
            {
                var copy = Instantiate(BtnSkill);
                Image image = copy.transform.GetChild(0).GetComponent<Image>();
                Text txtDescription = copy.transform.GetChild(1).GetComponent<Text>();
                Color c = image.color;
                c.a = 1f;
                image.color = c;
                txtDescription.text = "Day la skill rat la dep mat va bo ich , dung no ban co the tang suc manh";
                txtDescription.color = Color.black;
                Debug.Log("i" + i);
                //this.gameObject.GetComponent<Button>().interactable = false;
                copy.transform.parent = ContainerSkill.transform;
            }
        }

        void addPanelHeal()
        {
            GameObject PanelHeal = GameObject.Find("PanelHeal");
            GameObject PanelListHeal = GameObject.Find("PanelListHeal");
            for (var i = 0; i < 4; i++)
            {
                PanelHeal.transform.GetChild(0).GetComponent<Text>().text = "Health";
                PanelHeal.transform.GetChild(2).GetComponent<Text>().text = "9999";
                var copy = Instantiate(PanelHeal);
                copy.transform.parent = PanelListHeal.transform;
            }
        }

        void cbAwakeFail(string json)
        {
            PanelIDetail.SetActive(true);
            addStar();
            addPanelHeal();
            GameObject imgCharacter = GameObject.Find("AvtEditScreen");
            GameObject txtNameCharacter = GameObject.Find("txtNameCharacter");
            ImageController controllerImg = imgCharacter.GetComponent<ImageController>();
            controllerImg.setGameObject(imgCharacter);
            JObject data = JObject.Parse(dataCharacter);
            controllerImg.setUriImage(data["avatar"].ToString());
            Debug.Log("[dataCharacter]:" + json);
            txtNameCharacter.GetComponent<Text>().text = data["name"].ToString();

        }

        // Update is called once per frame
        void Start()
        {
        }

    }
}