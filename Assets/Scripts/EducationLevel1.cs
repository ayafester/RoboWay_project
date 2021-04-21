using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationLevel1 : MonoBehaviour
{
    public GameObject panel1;
    public int level;
    public GameObject education;

    void Start()
    {
        panel1.SetActive(true);
        panel1.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void NextPanel(int num)
    {
       panel1.transform.GetChild(num).gameObject.SetActive(true);
       panel1.transform.GetChild(num - 1).gameObject.SetActive(false);
    }

    public void ClosePanel()
    {
        //panel1.transform.GetChild(10).gameObject.SetActive(false);
        panel1.SetActive(false);
        if(level == 1)
        {
            education.GetComponent<CanvasGroup>().alpha = 0.4f;
        }

    }
}
