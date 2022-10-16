using System.Collections;
using UnityEngine;

namespace Assets.scripts.EditScreen
{
    public class LayoutBtnSkillScale : MonoBehaviour
    {
        public static LayoutBtnSkillScale instance;
        public GameObject Layout;
        public void Awake()
        {
            Layout = GameObject.Find("LayoutBtnSkillScale");
            instance = this;
        }
        // Use this for initialization
        public void onClick ()
        {
            Debug.Log("Click");
            Layout.SetActive(false);
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}