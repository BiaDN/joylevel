using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.scripts.ContainerListCharacter
{
    public class NameContainterCharacter : MonoBehaviour
    {
        public static NameContainterCharacter Instance;
        Text txtTitle;
        //TextAlignment 
        // Use this for initialization
        private void Awake()
        {
            Instance = this;
        }
        void Start()
        {
            txtTitle = GetComponent<Text>();
        }

        public void setText(string txt)
        {
            txtTitle.text = txt;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}