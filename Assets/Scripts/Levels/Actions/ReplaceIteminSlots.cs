using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceIteminSlots : MonoBehaviour
{
    private GameObject slots;
    private GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        slots = this.gameObject;
        text = slots.transform.Find("Text").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var childCount = slots.transform.childCount;
        if(childCount == 1)
        {
            text.SetActive(true);

        } else if(childCount >= 2)
        {
            text.SetActive(false);
        }
    }
}
