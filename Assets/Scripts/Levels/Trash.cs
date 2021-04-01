using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Trash : MonoBehaviour, IDropHandler
{
    private Trash thisDrop;
   

    private void Start()
    {
       
        thisDrop = this;
    }
    public void OnDrop(PointerEventData eventData)
    {
        
        var item = DragItem.dragItem;
        Destroy(item.gameObject);
        
    }

    
}
