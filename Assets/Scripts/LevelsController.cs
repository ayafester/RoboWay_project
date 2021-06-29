using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelsController : MonoBehaviour
{
    public int block;

    private int bestComm;
    private int command;

    public Button level1B;
    public Button level2B;
    public Button level3B;
    public Button level4B;
    public Button level5B;
    public Button level6B;

    int level1;
    int level2;
    int level3;
    int level4;
    int level5;
    int level6;

    // Start is called before the first frame update
    void Start()
    {
        
        PlayerPrefs.GetInt("Block2", 0);
        PlayerPrefs.GetInt("Block3", 0);

        level2B.interactable = false;
        level3B.interactable = false;
        level4B.interactable = false;
        level5B.interactable = false;
        level6B.interactable = false;


        if (block == 1)
        {
            level1 = PlayerPrefs.GetInt("LevelName11");
            level2 = PlayerPrefs.GetInt("LevelName12");
            level3 = PlayerPrefs.GetInt("LevelName13");
            level4 = PlayerPrefs.GetInt("LevelName14");
            level5 = PlayerPrefs.GetInt("LevelName15");
            level6 = PlayerPrefs.GetInt("LevelName16");


            if (level1 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand11");
                command = PlayerPrefs.GetInt("CounterCommand11");

                if (bestComm == command)
                {
                    level1B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level1B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level1B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level2B.interactable = true;
            }
            if (level2 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand12");
                command = PlayerPrefs.GetInt("CounterCommand12");


                if (bestComm == command)
                {
                    level2B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level2B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level2B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level3B.interactable = true;
            }
            if (level3 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand13");
                command = PlayerPrefs.GetInt("CounterCommand13");


                if (bestComm == command)
                {
                    level3B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level3B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level3B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level4B.interactable = true;
            }
            if (level4 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand14");
                command = PlayerPrefs.GetInt("CounterCommand14");


                if (bestComm == command)
                {
                    level4B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level4B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level4B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level5B.interactable = true;
            }

            if (level5 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand15");
                command = PlayerPrefs.GetInt("CounterCommand15");


                if (bestComm == command)
                {
                    level5B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level5B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level5B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level6B.interactable = true;
            }
            if (level6 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand16");
                command = PlayerPrefs.GetInt("CounterCommand16");


                if (bestComm == command)
                {
                    level6B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level6B.GetComponent<Image>().color = new Color(255 / 255.0f, 233 / 255.0f, 83 / 255.0f, 255 / 255.0f);
                }
                else
                {
                    level6B.GetComponent<Image>().color = new Color(255 / 255.0f, 103 / 255.0f, 102 / 255.0f, 255 / 255.0f);
                }
                PlayerPrefs.SetInt("Block2", 1);
            }

        } else if(block == 2)
        {
            level1 = PlayerPrefs.GetInt("LevelName21");
            level2 = PlayerPrefs.GetInt("LevelName22");
            level3 = PlayerPrefs.GetInt("LevelName23");
            level4 = PlayerPrefs.GetInt("LevelName24");
            level5 = PlayerPrefs.GetInt("LevelName25");
            level6 = PlayerPrefs.GetInt("LevelName26");


            if (level1 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand21");
                command = PlayerPrefs.GetInt("CounterCommand21");

                if (bestComm == command)
                {
                    level1B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level1B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level1B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level2B.interactable = true;
            }
            if (level2 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand22");
                command = PlayerPrefs.GetInt("CounterCommand22");


                if (bestComm == command)
                {
                    level2B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level2B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level2B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level3B.interactable = true;
            }
            if (level3 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand23");
                command = PlayerPrefs.GetInt("CounterCommand23");


                if (bestComm == command)
                {
                    level3B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level3B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level3B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level4B.interactable = true;
            }
            if (level4 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand24");
                command = PlayerPrefs.GetInt("CounterCommand24");


                if (bestComm == command)
                {
                    level4B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level4B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level4B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level5B.interactable = true;
            }

            if (level5 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand25");
                command = PlayerPrefs.GetInt("CounterCommand25");


                if (bestComm == command)
                {
                    level5B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level5B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level5B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level6B.interactable = true;
            }
            if (level6 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand26");
                command = PlayerPrefs.GetInt("CounterCommand26");


                if (bestComm == command)
                {
                    level6B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level6B.GetComponent<Image>().color = new Color(255 / 255.0f, 233 / 255.0f, 83 / 255.0f, 255 / 255.0f);
                }
                else
                {
                    level6B.GetComponent<Image>().color = new Color(255 / 255.0f, 103 / 255.0f, 102 / 255.0f, 255 / 255.0f);
                }
                PlayerPrefs.SetInt("Block3", 1);
            }
        } else if(block == 3)
        {
            level1 = PlayerPrefs.GetInt("LevelName31");
            level2 = PlayerPrefs.GetInt("LevelName32");
            level3 = PlayerPrefs.GetInt("LevelName33");
            level4 = PlayerPrefs.GetInt("LevelName34");
            level5 = PlayerPrefs.GetInt("LevelName35");
            level6 = PlayerPrefs.GetInt("LevelName36");


            if (level1 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand31");
                command = PlayerPrefs.GetInt("CounterCommand31");

                if (bestComm == command)
                {
                    level1B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level1B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level1B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level2B.interactable = true;
            }
            if (level2 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand32");
                command = PlayerPrefs.GetInt("CounterCommand32");


                if (bestComm == command)
                {
                    level2B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level2B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level2B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level3B.interactable = true;
            }
            if (level3 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand33");
                command = PlayerPrefs.GetInt("CounterCommand33");


                if (bestComm == command)
                {
                    level3B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level3B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level3B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level4B.interactable = true;
            }
            if (level4 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand34");
                command = PlayerPrefs.GetInt("CounterCommand34");


                if (bestComm == command)
                {
                    level4B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level4B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level4B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level5B.interactable = true;
            }

            if (level5 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand35");
                command = PlayerPrefs.GetInt("CounterCommand35");


                if (bestComm == command)
                {
                    level5B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level5B.GetComponent<Image>().color = new Color(255/255.0f, 233/255.0f, 83/255.0f, 255/255.0f);
                }
                else
                {
                    level5B.GetComponent<Image>().color = new Color(255/255.0f, 103/255.0f, 102/255.0f, 255/255.0f);
                }
                level6B.interactable = true;
            }
            if (level6 != 0)
            {
                bestComm = PlayerPrefs.GetInt("BestCommand36");
                command = PlayerPrefs.GetInt("CounterCommand36");


                if (bestComm == command)
                {
                    level6B.GetComponent<Image>().color = new Color(0 / 255.0f, 249 / 255.0f, 167 / 255.0f, 255 / 255.0f);
                }
                else if (command == (bestComm + 2) || command == (bestComm + 1))
                {
                    level6B.GetComponent<Image>().color = new Color(255 / 255.0f, 233 / 255.0f, 83 / 255.0f, 255 / 255.0f);
                }
                else
                {
                    level6B.GetComponent<Image>().color = new Color(255 / 255.0f, 103 / 255.0f, 102 / 255.0f, 255 / 255.0f);
                }
            }

        }
        
    }

}
