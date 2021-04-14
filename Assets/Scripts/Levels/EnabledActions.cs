using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledActions : MonoBehaviour
{
    public GameObject thisSlot;
   
    void Update()
    {
        if(thisSlot.transform.childCount > 1)
        {
            if (thisSlot.transform.GetChild(1).tag == "if" || thisSlot.transform.GetChild(1).tag == "func"
                || thisSlot.transform.GetChild(1).tag == "take" )
            {
                Destroy(thisSlot.transform.GetChild(1).gameObject);
            }
        }
    }
}
