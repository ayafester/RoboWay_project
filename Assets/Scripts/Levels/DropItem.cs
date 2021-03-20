using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    private DropItem thisSlot;
    private int childCount;
    //private GameObject text;
    private void Start()
    {
        thisSlot = this;
        childCount = thisSlot.transform.childCount;
        //text = thisSlot.transform.Find("Text").gameObject;
    }
    public void OnDrop(PointerEventData eventData)
    {
        childCount = thisSlot.transform.childCount; //получаем количество детей у объекта
        var item = DragItem.dragItem;
        
        if (item.transform.Find("DragItem") != null)
        {
            var script = item.GetComponent<DragItem>();
            Destroy(script);
        }

        if (item != null)
        {
            
            if (childCount == 1)
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
