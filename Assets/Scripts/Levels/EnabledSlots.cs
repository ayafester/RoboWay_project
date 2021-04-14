using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnabledSlots : MonoBehaviour
{
    public GameObject myLight;
    public bool isCondition;

    public class Slots //класс слот
    {
        public Transform slot; //наш слот
        public bool isActive;//активный
        public DropItem script;//скрипт, позволяющий положить туда элемент

    }; 

    public GameObject _slot; //слот родитель
    private List<Slots> slotsList = new List<Slots>();
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
        if(!isCondition) //когда работаем с обычным слотом
        {
            if (slotsList[0].slot.childCount == 1)
            {
                slotsList[0].slot.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);

                myLight.transform.position = slotsList[0].slot.position;
                myLight.GetComponent<Image>().color = slotsList[0].slot.GetComponent<Image>().color;

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
                    for (int m = 0; m < _slot.transform.childCount; m++)
                    {
                        slotsList[m].slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                    }

                    slotsList[i + 1].script.enabled = true;
                    slotsList[i + 1].slot.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);

                    myLight.transform.position = slotsList[i + 1].slot.position;
                    myLight.GetComponent<Image>().color = slotsList[i + 1].slot.GetComponent<Image>().color;
                }
                else
                {
                    for (int k = i; k < _slot.transform.childCount; k++)
                    {
                        if (slotsList[k].slot.childCount > 1)
                        {
                            Destroy(slotsList[k].slot.GetChild(1).gameObject);
                            slotsList[k].slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                        }
                    }
                }
            }
        } else
        {
            myLight.SetActive(false);

            if(ConditionEnabled.isActiveCondition)
            {
                myLight.SetActive(true);
                if (slotsList[0].slot.childCount == 1)
                {
                    slotsList[0].slot.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);

                    myLight.transform.position = slotsList[0].slot.position;
                    myLight.GetComponent<Image>().color = slotsList[0].slot.GetComponent<Image>().color;

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
                        for (int m = 0; m < _slot.transform.childCount; m++)
                        {
                            slotsList[m].slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                        }

                        slotsList[i + 1].script.enabled = true;
                        slotsList[i + 1].slot.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);

                        myLight.transform.position = slotsList[i + 1].slot.position;
                        myLight.GetComponent<Image>().color = slotsList[i + 1].slot.GetComponent<Image>().color;
                    }
                    else
                    {
                        for (int k = i; k < _slot.transform.childCount; k++)
                        {
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
        

    }
}
