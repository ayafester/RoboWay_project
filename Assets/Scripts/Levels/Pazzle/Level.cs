using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public RectTransform det1;
    public RectTransform det2;
    public RectTransform det3;
    public RectTransform det4;
    public RectTransform det5;
    public RectTransform det6;


    public RectTransform place1;
    public RectTransform place2;
    public RectTransform place3;
    public RectTransform place4;
    public RectTransform place5;
    public RectTransform place6;

    public int level;
    public int block;
    public int bestCommand;

    public GameObject ResultPanel;

    private int counterCommand;
    private string levelName;
    // Start is called before the first frame update
    void Start()
    {
        ResultPanel.SetActive(false);
        counterCommand = 4;
        levelName = block.ToString() + level.ToString();
        if(PlayerPrefs.GetInt("LevelName" + levelName) == 0)
        {
            PlayerPrefs.SetInt("LevelName" + levelName, 0);
        }
    }

    public void Result()
    {
        PlayerPrefs.SetInt("LevelName" + levelName, 1);
        PlayerPrefs.SetInt("BestCommand" + levelName, bestCommand);
        PlayerPrefs.SetInt("CounterCommand" + levelName, counterCommand);
    }

    
    // Update is called once per frame
    void Update()
    {
        if(block == 1)
        {
            if (det1.anchoredPosition == place1.anchoredPosition
            && det2.anchoredPosition == place2.anchoredPosition
            && det3.anchoredPosition == place3.anchoredPosition
            && det4.anchoredPosition == place4.anchoredPosition)
            {
                ResultPanel.SetActive(true);
                Result();
            }
        }
        if(block == 2)
        {
            if (det1.anchoredPosition == place1.anchoredPosition
            && det2.anchoredPosition == place2.anchoredPosition
            && det3.anchoredPosition == place3.anchoredPosition
            && det4.anchoredPosition == place4.anchoredPosition
            && det5.anchoredPosition == place5.anchoredPosition
            && det6.anchoredPosition == place6.anchoredPosition)
            {
                ResultPanel.SetActive(true);
                Result();
            }
        }
        if (block == 3)
        {
            if (det1.anchoredPosition == place1.anchoredPosition
            && det2.anchoredPosition == place2.anchoredPosition
            && det3.anchoredPosition == place3.anchoredPosition
            && det4.anchoredPosition == place4.anchoredPosition
            && det5.anchoredPosition == place5.anchoredPosition
            && det6.anchoredPosition == place6.anchoredPosition)
            {
                ResultPanel.SetActive(true);
                Result();
            }
        }
    }
}
