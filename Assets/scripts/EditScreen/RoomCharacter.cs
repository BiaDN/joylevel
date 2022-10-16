using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.scripts.EditScreen
{
    public class RoomCharacter : MonoBehaviour, IDropHandler
    {

        // Use this for initialization
        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            Debug.Log("ASASA OnDrop");
            if(eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            }
        }
    }
}