using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public class Slots //класс слот
    {
        public Transform slot;
        public bool isActive;
        public DropItem script;

    };

    public GameObject _slot; //слот родитель
    private List<Slots> slotsList = new List<Slots>(); //массив с экземлпярами слотов




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
        
        for (int i = 0; i < _slot.transform.childCount; i++)
        {
            slotsList.Add( new Slots() ); //13 экземпляров
        }
        for (int i = 0; i < _slot.transform.childCount; i++)
        {
            slotsList[i].slot = _slot.transform.GetChild(i); //инициализирован слот из юнити
            slotsList[i].isActive = false;
            slotsList[i].script = slotsList[i].slot.GetComponent<DropItem>();
            slotsList[i].script.enabled = false;
        }
        slotsList[0].script.enabled = true;


        recttrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>(); //получаем компонент канвас группы для тек.элемента
        dragLayer = GameObject.FindGameObjectWithTag("DragLayer").GetComponent<RectTransform>();//находим по тегу
        currentSlot = transform.parent;//присвиваем текущему слоту родителя

    }
    private void Update()
    {
        if(slotsList[0].slot.childCount == 1)
        {
            slotsList[0].slot.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);
            for (int i = 1; i < 13; i++)
            {
                slotsList[i].slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            }
        }
        

        for (int i = 0; i < 13; i++)
        {
            if (slotsList[i].slot.childCount == 2)
            {
                //slotsList[i].slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                //slotsList[i+1].slot.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);
                for (int m = 0; m < 13; m++)
                {
                    slotsList[m].slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                }

                slotsList[i+1].script.enabled = true;
                slotsList[i + 1].slot.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);

            }
            else
            {
                for (int k = i; k < 13; k++)
                {
                    //slotsList[k].slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                    if (slotsList[k].slot.childCount > 1 )
                    {
                        Destroy(slotsList[k].slot.GetChild(1).gameObject);
                        slotsList[k].slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                        
                    }
                    

                }
            }
        }

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        //Debug.Log(currentSlot);
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
        //transform.position = Input.mousePosition;//меняем позиции
        recttrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (slot == null) //если не переместили в новый слот
        {
            //Debug.Log("тут должно быть удаление копии и перемещение обратно в начальну");
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
