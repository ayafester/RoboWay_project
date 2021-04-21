using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputFieldEnabled : MonoBehaviour
{
    public InputField thisInput;
    public GameObject mylight;

    public static bool isInput = false;
    // Start is called before the first frame update
    void Start()
    {
        mylight.GetComponent<Image>().color = thisInput.GetComponent<Image>().color;
        mylight.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isInput);
        if(thisInput.GetComponent<InputField>().text != "")
        {
            Debug.Log(thisInput.GetComponent<InputField>().text);
            isInput = true;
            mylight.SetActive(false);
        }
    }
}
