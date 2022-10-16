using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.scripts.EditScreen
{
    public class BtnEditController : MonoBehaviour
    {
        public GameObject InputNameCharacter;
        public GameObject BtnEdit;

        // Use this for initialization
        public void BtnEditonClick()
        {
            InputNameCharacter.GetComponent<InputField>().interactable = true;
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