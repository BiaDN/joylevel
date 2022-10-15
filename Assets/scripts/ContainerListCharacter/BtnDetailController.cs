using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.scripts.ContainerListCharacter
{
    public class BtnDetailController : MonoBehaviour
    {
        public GameObject btnDetails;
        //public string urlImage;
        public GameObject container;
        public static BtnDetailController instance;
        private string txtNameChracter;

        // Use this for initialization

        public static BtnDetailController GetInstance()
        {
            Debug.Log("GetInstance " + instance);
            return instance;
        }
        public void setTxtNameCharacter(string txtName)
        {
            txtNameChracter = txtName;
        }

        public void setGameObjectChild(GameObject objectChild)
        {
            btnDetails = objectChild;
        }

        public void setGameObjectParent(GameObject objectParent)
        {
            container = objectParent;
        }
        void Start()
        {
            instance = this;
        }

        // Update is called once per frame
        public void addChildToContent()
        {
            for(var i =0;i <3;i++)
            {
                var copy = Instantiate(btnDetails);
                GameObject txtName = copy.transform.GetChild(1).gameObject;
                txtName.GetComponent<Text>().text = txtNameChracter;
                copy.transform.parent = container.transform;
            }
            //copy.transform.parent = container.transform;
            //copy.transform.parent = container.transform;
        }
        //void Update()
        //{

        //}
    }
}