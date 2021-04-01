using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    public GameObject Slots;
    public List<Transform> slotsList;//массив слотов

    public GameObject Actions;
    public List<Transform> actionList;//массив слотов

    private void Start()
    {
        for (int i = 0; i < Slots.transform.childCount; i++)
        {
            slotsList.Add(Slots.transform.GetChild(i)); //инициализация слотов
        }
        for (int i = 0; i < Actions.transform.childCount; i++)
        {
            actionList.Add(Actions.transform.GetChild(i)); //инициализация слотов
        }
    }

    public void OnClick(int i)
    {
        int thisSlot;

        if (i == 0)
        {
            thisSlot = EmptySlot();
            var dragItemCopy = Instantiate(actionList[0].GetChild(0).gameObject,
                slotsList[thisSlot].position,
                actionList[0].GetChild(0).rotation, slotsList[thisSlot]);

        } else if( i == 1 )
        {

        } else if( i == 2 )
        {

        }
    }
    private int EmptySlot()
    {
        int num = 13;
        for (int i = 0; i < Slots.transform.childCount; i++)
        {
            if(slotsList[i].childCount == 1)
            {
                num = i;
                return num;
            } 
        }
        return num;
    }
}