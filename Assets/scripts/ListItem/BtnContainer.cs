using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.scripts.ListItem
{
    public class BtnContainer : MonoBehaviour
    {

        // Use this for initialization
        public void moveToEditScene(int sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }

        public void moveToMainScreen(int sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }

        // Update is called once per frame
    }
}