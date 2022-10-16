using System.Collections;
using UnityEngine;

namespace Assets.scripts.EditScreen.Button
{
    public class BtnCanceEditPostion : MonoBehaviour
    {

        // Use this for initialization
        public GameObject LayoutEditPositionCharacter;
        public void BtnCanceEditPostionOnClick ()
        {
            LayoutEditPositionCharacter.SetActive(false);
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