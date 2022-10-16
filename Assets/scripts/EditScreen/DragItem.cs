using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.scripts.EditScreen
{
    public class DragItem : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler,IDropHandler
    {
        [SerializeField] private Canvas canvas;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        public void Awake()
        {
            rectTransform = gameObject.GetComponent<RectTransform>();
            canvasGroup = gameObject.GetComponent<CanvasGroup>();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag");
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            Debug.Log("OnDragItem");
            throw new System.NotImplementedException();
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag");
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }
}