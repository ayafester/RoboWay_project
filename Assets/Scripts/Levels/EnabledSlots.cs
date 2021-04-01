﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledSlots : MonoBehaviour
{
    public class Slots //класс слот
    {
        public Transform slot; //наш слот
        public bool isActive;//активный
        public DropItem script;//скрипт, позволяющий положить туда элемент

        public void isActiveValue(bool itis)
        {
            if (itis == true)
            {
                slot.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1.1f);
                script.enabled = true;
                isActive = true;
            } else
            {
                slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                script.enabled = false;
                isActive = false;
            }
        }
    }; 

    public GameObject _slot; //слот родитель
    private List<Slots> slotsList = new List<Slots>();
    private DropItem thiSlot;
    int valueOfSlot;
    void Start()
    {
        for (int i = 0; i < _slot.transform.childCount; i++)
        {
            slotsList.Add(new Slots());
        }
        for (int i = 0; i < _slot.transform.childCount; i++)
        {
            slotsList[i].slot = _slot.transform.GetChild(i); 
            slotsList[i].script = slotsList[i].slot.GetComponent<DropItem>();
            slotsList[i].script.enabled = false;
        }
    }

    void Update()
    {
        if (slotsList[0].slot.childCount == 1)
        {
            slotsList[0].slot.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);
            slotsList[0].slot.GetComponent<DropItem>().enabled = true;

            for (int i = 1; i < _slot.transform.childCount; i++)
            {
                slotsList[i].slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            }
        }


        for (int i = 0; i < _slot.transform.childCount; i++)
        {
            if (slotsList[i].slot.childCount == 2)
            {
                //slotsList[i].slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                //slotsList[i+1].slot.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);
                for (int m = 0; m < _slot.transform.childCount; m++)
                {
                    slotsList[m].slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                }

                slotsList[i + 1].script.enabled = true;
                slotsList[i + 1].slot.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);

            }
            else
            {
                for (int k = i; k < _slot.transform.childCount; k++)
                {
                    //slotsList[k].slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                    if (slotsList[k].slot.childCount > 1)
                    {
                        Destroy(slotsList[k].slot.GetChild(1).gameObject);
                        slotsList[k].slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);

                    }


                }
            }
        }

    }
}