using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledSlots : MonoBehaviour
{
    public class Slots //класс слот
    {
        public Transform slot;
        public bool isActive;

    };

    public GameObject slot; //слот родитель
    private List<Slots> slotsList; //массив с экземлпярами слотов
    
    void Start()
    {
        
        for (int i = 0; i < slot.transform.childCount; i++)
        {
            slotsList.Add(new Slots()); //13 экземпляров
        }
        for (int i = 0; i < slot.transform.childCount; i++)
        {
            slotsList[i].slot = slot.transform.GetChild(i); //инициализирован слот из юнити
        }
    }

    private void FixedUpdate()
    {
       
    }
}
