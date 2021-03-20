using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class DropItem : MonoBehaviour, IDropHandler
{
   
    private DropItem thisSlot;
    private int childCount;
    
    private void Start()
    {
        thisSlot = this;
        childCount = thisSlot.transform.childCount;
    }
    private void Update()
    {
       
    }
    public void OnDrop(PointerEventData eventData)
    {
        childCount = thisSlot.transform.childCount; //получаем количество детей у объекта
        var item = DragItem.dragItem;
        
        if (item.transform.Find("DragItem") != null) 
        {
            Debug.Log("Непонятно что я делаю");
            var script = item.GetComponent<DragItem>();
            Destroy(script);
        }

        if (item != null)
        {
           
            if (childCount == 1) //если слот не больше одного
            {
                item.SetItemToSlot(transform);
                //text.SetActive(false);
                
            } else if(childCount == 2)
            {
                Destroy(thisSlot.transform.GetChild(1).gameObject);
                item.SetItemToSlot(transform);
                //text.SetActive(false);
               
            } 
            
        }
        
    }
}
