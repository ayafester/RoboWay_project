using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BlockController : MonoBehaviour
{
    public Button button2;
    public Button button3;

    private int block2;
    private int block3;

    // Start is called before the first frame update
    void Start()
    {
        

        block2 = PlayerPrefs.GetInt("Block2");
        block3 = PlayerPrefs.GetInt("Block3");

        if(block2 != 0)
        {
            button2.interactable = true;
        }
        if (block3 != 0)
        {
            button3.interactable = true;
        }

        Debug.Log(block3);
    }
}
