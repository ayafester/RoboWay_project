using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    /*public GameObject det1;
    public GameObject det2;
    public GameObject det3;
    public GameObject det4;
    private int num;

    public static bool isWin = false;
    public class isHome
    {
        public GameObject item;
        public bool isEnter;
    }
    private List<isHome> thisItems;*/

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
        /*for (int i = 0; i < 4; i++)
        {
            thisItems.Add( new isHome() );
        }

        thisItems[0].item = det1;
        thisItems[0].isEnter = false;
        thisItems[1].item = det2;
        thisItems[1].isEnter = false;
        thisItems[2].item = det3;
        thisItems[2].isEnter = false;
        thisItems[3].item = det4;
        thisItems[3].isEnter = false;

        for (int i = 0; i < 4; i++)
        {
            if (thisItems[i].item == this.gameObject)
            {
                thisItems[i].item = this.gameObject;
                num = i;
                break;
            }
        }*/
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
        if (rectTransform.anchoredPosition != place.anchoredPosition)
        {
            rectTransform.position = startPos;
        } 
        canvasGroup.blocksRaycasts = true;
    }

    private void Update()
    {
       /*if(thisItems[0].isEnter == true && thisItems[1].isEnter== true && thisItems[2].isEnter ==true && thisItems[3].isEnter == true)
        {
            isWin = true;
        }*/
          
    }
}
