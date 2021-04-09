using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   
    public Canvas canvas;
    public static DragItem dragItem; //текущий элемент, который взяли
    public static DragItem dragItemCopy; //копия текущего элемента
    public Transform currentSlot; //текущий объект, в котором лежит элемент
    private Vector3 startPosition; //стартовая позиция тек.элемента

    private Vector3 localScale; //стартовая позиция тек.элемента

    private RectTransform recttrans; 

    private Transform startParrent;//стартовый родитель тек.элемента
    private CanvasGroup canvasGroup;//канвас группа тек.элемента
    private CanvasGroup canvasGroupCopy;//канвас группа копии элемента
    private RectTransform dragLayer;//переменный слой при перетаскивании
    private Transform slot;//слот для элемента

    private void Start()
    {
        recttrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>(); //получаем компонент канвас группы для тек.элемента
        dragLayer = GameObject.FindGameObjectWithTag("DragLayer").GetComponent<RectTransform>();//находим по тегу
        currentSlot = transform.parent;//присвиваем текущему слоту родителя

    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
       
        slot = null; //обнуляем слот элемента
        dragItem = this; //присваиваем тек. элемент

        recttrans = dragItem.gameObject.GetComponent<RectTransform>();

        startPosition = transform.position;
        startParrent = transform.parent;
        localScale = transform.localScale;

        transform.SetParent(dragLayer); //когда начинаем перетаскивать, то делаем родителя временный слой
        canvasGroup.blocksRaycasts = false;//открываем блок

        if (currentSlot.tag != "Slot") //создаем копию, только если наш объект находится не на слотах итоговых
        {
            dragItemCopy = Instantiate(dragItem, startPosition, recttrans.rotation, startParrent);
            
            dragItemCopy.transform.localScale = localScale;
            canvasGroupCopy = dragItemCopy.GetComponent<CanvasGroup>();//присваиваем канвас группу скопированного элемента
            canvasGroupCopy.blocksRaycasts = true;//закрываем блок
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    { 

        recttrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (slot == null) //если не переместили в новый слот
        {
            transform.SetParent(startParrent); //то присваиваем стартовую позицию и параметры
            transform.position = startPosition;
            if (currentSlot.tag != "Slot")
            {
                Destroy(dragItemCopy.gameObject);
            }
            
        }

        dragItem = null;
        canvasGroup.blocksRaycasts = true;//закрываем блок
        slot = null;
    }

    public void SetItemToSlot(Transform slot)
    {
        this.slot = slot; //присваиваем слоту позицию
        transform.SetParent(slot);
        currentSlot = slot;
        transform.localPosition = Vector3.zero;
    }
}
