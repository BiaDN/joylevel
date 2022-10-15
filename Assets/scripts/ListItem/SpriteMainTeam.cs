using scripts.Network;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.scripts.ListItem
{
    public class SpriteMainTeam : MonoBehaviour
    {

        // Use this for initialization
        public Sprite spriteMainTeam;
        public static SpriteMainTeam Instance;
        public string idCharacter;

        public void Awake()
        {
            //var parent = (this.gameObject.transform as RectTransform);
            //var sprite = GetComponent<SpriteRenderer>().sprite;
            //parent.localScale = parent.rect.size / sprite.rect.size * sprite.pixelsPerUnit;
            Instance = this;
        }

        public static SpriteMainTeam GetInstance()
        {
            return Instance;
        }
        void Start()
        {

        }

        public void setIdCharacter(string id)
        {
            idCharacter = id;
        }

        // Update is called once per frame
        public void updateSprite()
        {
            
            //this.gameObject.GetComponent<Button>().interactable = false;

            //this.gameObject.GetComponent<Image>().color = colorFound.a;
        }

        public void disableButtonSetMainTeam()
        {
            Image image = this.gameObject.GetComponent<Image>();
            Color c = image.color;
            c.a = 0.5f;
            image.color = c;
            this.gameObject.GetComponent<Button>().interactable = false;
        }

        public void onClickSetMainTeam()
        {
            Dictionary<string, string> body = new Dictionary<string, string>();
            Dictionary<string, string> inputVals = new Dictionary<string, string>();
            body.Add("idCharacter", idCharacter);
            body.Add("idUser", "634a39c0c11bc9c06f7dca95");

            NetworkController.Instance.callPostAPI(NetworkConst.URL_POST_EQUIP_CHARACTER, body, inputVals, cbSetMainTeamSuccess, cbSetMainTeamFail);
        }

        public void ResetInfo()
        {
            Debug.Log("reset");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void cbSetMainTeamFail(string json)
        {
            Debug.Log(" cbSetMainTeamFail " + json);

        }

        public void cbSetMainTeamSuccess(string json)
        {
            Debug.Log("cbSetMainTeamSuccess " + json);
            ResetInfo();
        }
    }
}