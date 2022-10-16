using System.Collections;
using UnityEngine;

namespace Assets.scripts.EditScreen.Layout
{
    public class LayoutEditPositionCharacter : MonoBehaviour
    {
        public static LayoutEditPositionCharacter instance;
        public GameObject Layout;
        public void Awake()
        {
            Layout = GameObject.Find("LayoutEditPositionCharacter");
            instance = this;
        }
        // Use this for initialization
        public void onClick()
        {
            Debug.Log("Click");
            Layout.SetActive(false);
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}