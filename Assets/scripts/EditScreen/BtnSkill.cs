using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.scripts.EditScreen
{
    public class BtnSkill : MonoBehaviour
    {
        public GameObject BtnSkillScale;
        public GameObject LayoutBtnSkillScale;
        // Use this for initialization
        public void Awake()
        {
            Image image = BtnSkillScale.transform.GetChild(0).GetComponent<Image>();
            Text txtDescription = BtnSkillScale.transform.GetChild(1).GetComponent<Text>();
            Color c = image.color;
            c.a = 1f;
            image.color = c;
            Image imgLayout = LayoutBtnSkillScale.GetComponent<Image>();
            Color colorLayout = imgLayout.color;
            colorLayout.a = 0f;
            imgLayout.color = colorLayout;
            txtDescription.text = "Day la skill rat la dep mat va bo ich , dung no ban co the tang suc manh";
            txtDescription.color = Color.black;
        }
        public void onClickScale(int id)
        {
            LayoutBtnSkillScale.SetActive(true);

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