using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class DropItem : MonoBehaviour, IDropHandler
{
    public GameObject IfSlots;
    DragItem item;
    public GameObject Slot;
   
    private List<Transform> slotsList = new List<Transform>();
   
    public int situation;
    private DropItem thisSlot;
    private int childCount;

    private void Start()
    {
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        
        thisSlot = this;
        //Debug.Log(thisSlot.transform.position);
        childCount = thisSlot.transform.childCount;

        for (int i = 0; i < Slot.transform.childCount; i++)
        {
            slotsList.Add(Slot.transform.GetChild(i));
        }
        //Debug.Log(slotsList);

        Debug.Log("работает ондроп!");
        item = DragItem.dragItem;
        childCount = thisSlot.transform.childCount; //получаем количество детей у объекта
        
        if(situation == 2) // в случае с работой со слотами и с действиями
        {
            if (item != null)
            {
                if (item.tag != "WallWood")
                {
                    if (thisSlot.transform.childCount == 1)
                   {
                        if (item.tag == "if")
                        {
                            item.SetItemToSlot(transform);
                            SetColor();
                        } else
                        {
                            item.SetItemToSlot(transform);
                        }
                   } else if (thisSlot.transform.childCount == 2)
                   {
                        Destroy(thisSlot.transform.GetChild(1).gameObject); //заменяем обьект на новый
                        if (thisSlot.transform.GetChild(1).gameObject.tag == "if")
                        {
                            DeleteColor(); 
                        }
                        item.SetItemToSlot(transform);
                        if(item.tag == "if")
                        {
                            SetColor();
                        }
                    }
                } 
            }
        } else if(situation == 1)
        {
            if (item.tag == "WallWood")
            {
                if (childCount == 0) 
                {
                    item.SetItemToSlot(transform);
                }
                else if (childCount == 1)
                {
                    Destroy(thisSlot.transform.GetChild(thisSlot.transform.childCount - 1).gameObject);
                    item.SetItemToSlot(transform);
                }
            } 
        }
       /*if (item.transform.Find("DragItem") != null) 
        {
            Debug.Log("Непонятно что я делаю");
            var script = item.GetComponent<DragItem>();
            Destroy(script);
        }*/
        
    }

    private void SetColor()
    {
        IfSlots.GetComponent<CanvasGroup>().alpha = 1f;
        for (int i = 2; i < IfSlots.transform.childCount; i++)
        {
            Debug.Log("aiaia");
            IfSlots.transform.GetChild(i).GetComponent<DropItem>().enabled = true;
        }
        
    }

    private void DeleteColor()
    {
        IfSlots.GetComponent<CanvasGroup>().alpha = 0.4f;
        for (int i = 0; i < IfSlots.transform.childCount; i++)
        {
            if(IfSlots.transform.GetChild(i).childCount == 2)
            {
                Destroy(IfSlots.transform.GetChild(i).transform.GetChild(1).gameObject);
            }
            if (IfSlots.transform.GetChild(i).GetComponent<DropItem>() != null)
            {
                IfSlots.transform.GetChild(i).GetComponent<DropItem>().enabled = false;
            }
        }
    }
}
