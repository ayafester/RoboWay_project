using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfEnabledSlots : MonoBehaviour
{
    public GameObject slots;
    private List<Transform> ifSlotsList;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 2; i < slots.transform.childCount; i++)
        {
            ifSlotsList.Add(slots.transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
