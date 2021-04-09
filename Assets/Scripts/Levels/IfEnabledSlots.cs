using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfEnabledSlots : MonoBehaviour
{
    public GameObject slots;
    public List<Transform> ifSlotsList;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 2; i < slots.transform.childCount; i++)
        {
            ifSlotsList.Add(slots.transform.GetChild(i));
            Debug.Log(ifSlotsList[i]);
        }
        ifSlotsList[0].gameObject.GetComponent<DropItem>().enabled = true;
        ifSlotsList[0].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        if (ifSlotsList[0].childCount == 1)
        {
            ifSlotsList[0].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);
            ifSlotsList[0].GetComponent<DropItem>().enabled = true;

            for (int i = 1; i < slots.transform.childCount; i++)
            {
                ifSlotsList[i].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            }
        }


        for (int i = 0; i < slots.transform.childCount; i++)
        {
            if (ifSlotsList[i].childCount == 2)
            {
                for (int m = 0; m < slots.transform.childCount; m++)
                {
                    ifSlotsList[m].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                }

                ifSlotsList[i + 1].GetComponent<DropItem>().enabled = true;
                ifSlotsList[i + 1].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1f);

            }
            else
            {
                for (int k = i; k < slots.transform.childCount; k++)
                {
                    if (ifSlotsList[k].childCount > 1)
                    {
                        Destroy(ifSlotsList[k].GetChild(1).gameObject);
                        ifSlotsList[k].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);

                    }


                }
            }
        }
    }
}
