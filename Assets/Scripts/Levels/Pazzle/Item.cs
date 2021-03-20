using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform place;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    private Vector3 startPos;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.position; //начальная позиция
       
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(rectTransform.anchoredPosition);
        if (rectTransform.anchoredPosition != place.anchoredPosition)
        {
            Debug.Log("Notthis!");
            rectTransform.position = startPos;
        }
        canvasGroup.blocksRaycasts = true;
 
    }

    
}
