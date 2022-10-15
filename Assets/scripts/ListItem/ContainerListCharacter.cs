using System.Collections;
using UnityEngine;

namespace Assets.scripts.ListItem
{
    public class ContainerListCharacter : MonoBehaviour
    {
        public GameObject txtTitleContainer;
        public static ContainerListCharacter _instance;
        public static ContainerListCharacter GetInstance()

          
        {
            return _instance;
        }
        // Use this for initialization
        public void Awake()
        {
            _instance = this;
        }

        public void setTxt(string name)
        {
            //txtTitleContainer.text = 
        }
    }
}