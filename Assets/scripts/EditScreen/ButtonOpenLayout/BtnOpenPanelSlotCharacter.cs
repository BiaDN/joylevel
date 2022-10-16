using System.Collections;
using UnityEngine;

namespace Assets.scripts.EditScreen.ButtonOpenLayout
{
    public class BtnOpenPanelSlotCharacter : MonoBehaviour
    {

        public GameObject LayoutEditPositionCharacter;
        // Use this for initialization
        public void Awake()
        {
        }
        public void onClickOpenLayout(int id)
        {
            LayoutEditPositionCharacter.SetActive(true);

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