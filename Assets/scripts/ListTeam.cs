using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTeam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itemTemplate;
    public GameObject content;

    public void btnCopyOnClick() {
        Debug.Log("click");
        var copy = Instantiate(itemTemplate);
        copy.transform.parent = content.transform;
        // itemTemplate.transform.SetParent(content.transform,false);
    }
}
