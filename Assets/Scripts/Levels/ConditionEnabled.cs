using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConditionEnabled : MonoBehaviour
{
    public static bool isActiveCondition = false;
    public GameObject thisCond;
    public GameObject Light;

    private void Start()
    {
        Light.GetComponent<Image>().color = thisCond.GetComponent<Image>().color;
    }
    void Update()
    {
        if (thisCond.transform.childCount == 0)
        {
            isActiveCondition = false;
        } else 
        {
            isActiveCondition = true;
            Light.SetActive(false);
        }
       
    }
}




