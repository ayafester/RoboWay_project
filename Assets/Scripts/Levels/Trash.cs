using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Trash : MonoBehaviour, IDropHandler
{
    private Trash thisDrop;
    public GameObject slot;
    private void Start()
    {
        thisDrop = this;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(DragItem.dragItem.tag == "if")
        {
            ActionIfFuncController.isIfActiv = false;
            slot.GetComponent<DropItem>().DeleteColor();
        } else if(DragItem.dragItem.tag == "func")
        {
            ActionIfFuncController.isIfActiv = false;
            slot.GetComponent<DropItem>().DeletColorFunc();
        }
        var item = DragItem.dragItem;
        Destroy(item.gameObject);
    }
 
}
