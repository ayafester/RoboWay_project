using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class DropItem : MonoBehaviour, IDropHandler
{
    public GameObject Condition;
    public GameObject LightCon;
    DragItem item;
    public GameObject Slot;
   
    private List<Transform> slotsList = new List<Transform>();
   
    public int situation;
    private DropItem thisSlot;
    private int childCount;
    public static int isIfWas;
    
    public void OnDrop(PointerEventData eventData)
    {
        
        thisSlot = this;
        childCount = thisSlot.transform.childCount;

        for (int i = 0; i < Slot.transform.childCount; i++)
        {
            slotsList.Add(Slot.transform.GetChild(i));
        }
        
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
                            if(ActionIfFuncController.isIfActiv == false)
                            {
                                item.SetItemToSlot(transform);
                                SetColor();
                            }

                        } else if (item.tag == "func") {

                            if (ActionIfFuncController.isIfActiv == false)
                            {
                                item.SetItemToSlot(transform);
                                SetColotFunc();
                            }
                        }
                        else
                        {
                            item.SetItemToSlot(transform);
                        }

                   } else if (thisSlot.transform.childCount == 2)
                   {
                        if(item.tag == "if" || item.tag == "func")
                        {
                            if(item.tag == "if")
                            {
                                if (ActionIfFuncController.isIfActiv == false)
                                {
                                    Destroy(thisSlot.transform.GetChild(1).gameObject);
                                    item.SetItemToSlot(transform);
                                    SetColor();
                                }
                            } else if(item.tag == "func")
                            {
                                if (ActionIfFuncController.isIfActiv == false)
                                {
                                    Destroy(thisSlot.transform.GetChild(1).gameObject);
                                    item.SetItemToSlot(transform);
                                    SetColotFunc();
                                }
                            }
                            
                        } else
                        {
                            Destroy(thisSlot.transform.GetChild(1).gameObject);
                            item.SetItemToSlot(transform);
                            if (thisSlot.transform.GetChild(1).gameObject.tag == "if")
                            {
                                DeleteColor();
                                ActionIfFuncController.isIfActiv = false;
                            }
                            if (thisSlot.transform.GetChild(1).gameObject.tag == "func")
                            {
                                DeletColorFunc();
                                ActionIfFuncController.isIfActiv = false;
                            }
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
    }
    private void Update()
    {
        
        /*
        for (int i = 0; i < slotsList.Count; i++)
        {
            if (slotsList[i].GetChild(1).tag == "if" || slotsList[i].GetChild(1).tag == "func")
            {
                isIfWas = 1;
                break;
            }
        }*/
    }
    private void SetColotFunc()
    {
        Condition.GetComponent<CanvasGroup>().alpha = 1f;
        Condition.transform.GetChild(1).transform.GetComponent<Button>().interactable = true;
        for (int i = 0; i < Condition.transform.GetChild(2).childCount; i++)
        {
            Condition.transform.GetChild(2).transform.GetChild(i).GetComponent<DropItem>().enabled = true;
            
        }
    }

    public void DeletColorFunc() 
    {
        Condition.GetComponent<CanvasGroup>().alpha = 0.4f;
        Condition.transform.GetChild(1).transform.GetComponent<Button>().interactable = false;
       
        for (int i = 0; i < Condition.transform.GetChild(2).childCount; i++)
        {
            Condition.transform.GetChild(2).transform.GetChild(i).GetComponent<DropItem>().enabled = false;
            if(Condition.transform.GetChild(2).transform.GetChild(i).childCount > 1)
            {
                Destroy(Condition.transform.GetChild(2).transform.GetChild(i).transform.GetChild(1).gameObject);
            }

        }
    }
    private void SetColor()
    {
        
        LightCon.SetActive(true);
        Move.isIfActive = true;

        Condition.GetComponent<CanvasGroup>().alpha = 1f;
        
        for (int i = 0; i < Condition.transform.GetChild(4).childCount; i++)
        {
            if(ConditionEnabled.isActiveCondition)
            {
                Condition.transform.GetChild(4).transform.GetChild(i).GetComponent<DropItem>().enabled = true;
            }
            
        }
        for (int i = 0; i < Condition.transform.GetChild(5).childCount; i++)
        {
            if(ConditionEnabled.isActiveCondition)
            {
                Condition.transform.GetChild(5).transform.GetChild(i).GetComponent<DropItem>().enabled = true;
            }
            
        }
    }

    public void DeleteColor()
    {
        ConditionEnabled.isActiveCondition = false;
        LightCon.SetActive(false);
        Move.isIfActive = false;
        Condition.GetComponent<CanvasGroup>().alpha = 0.4f;
        
        
        for (int i = 0; i < Condition.transform.GetChild(4).childCount; i++)
        {
            Condition.transform.GetChild(4).transform.GetChild(i).GetComponent<DropItem>().enabled = false;
            if(Condition.transform.GetChild(4).transform.GetChild(i).childCount > 1)
            {
                Destroy(Condition.transform.GetChild(4).transform.GetChild(i).transform.GetChild(1).gameObject);
            }
        }
        for (int i = 0; i < Condition.transform.GetChild(5).childCount; i++)
        {
            Condition.transform.GetChild(5).transform.GetChild(i).GetComponent<DropItem>().enabled = false;

            if (Condition.transform.GetChild(5).transform.GetChild(i).childCount > 1)
            {
                Destroy(Condition.transform.GetChild(5).transform.GetChild(i).transform.GetChild(1).gameObject);
            }
        }
        
    }
}
