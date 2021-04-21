using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionIfFuncController : MonoBehaviour
{
    public GameObject slot;
    public static bool isIfActiv;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isIfActiv);
        for (int i = 0; i < slot.transform.childCount; i++)
        {
            if (slot.transform.GetChild(i).transform.childCount > 1)
            {
                if(slot.transform.GetChild(i).transform.GetChild(1).tag == "if" || 
                    slot.transform.GetChild(i).transform.GetChild(1).tag == "func")
                {
                    isIfActiv = true;
                    
                } else
                {
                    isIfActiv = false;
                }
            }
        }
    }
}
