using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.scripts.ListItem
{
    public class BtnContainer : MonoBehaviour
    {
        public string idCharacter;
        public string dataCharacter;
        // Use this for initialization
        public void SetIdCharacter (string id)
        {
            idCharacter = id;
        }

        public void SetIdDataCharacter(string data)
        {
            dataCharacter = data;
        }
        public void moveToEditScene(int sceneId)
        {
            PlayerPrefs.SetString("idCharacter", idCharacter);
            PlayerPrefs.SetString("dataCharacter", dataCharacter);
            SceneManager.LoadScene(sceneId);
        }

        public void moveToMainScreen(int sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }

        // Update is called once per frame
    }
}