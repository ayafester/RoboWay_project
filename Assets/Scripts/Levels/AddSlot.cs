using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddSlot : MonoBehaviour
{
    public GameObject Slots;

    public GameObject SlotParrentUp;
    public GameObject SlotParrentDown;

    public GameObject example;

    public int value;
    private GameObject newSlot;

    public List<GameObject> newSlotsListUp = new List<GameObject>();
    public List<GameObject> newSlotsListDown = new List<GameObject>();


    private int numOfthisSlot;
    int z = 14;
   
    public void onClickAdd(int value)
    {
        var thisAdd = new CheckLength();
        
        for (int k = 0; k < Slots.transform.childCount; k++)
        {
            if (Slots.transform.GetChild(k).gameObject.tag ==  "if")
            {
                numOfthisSlot = k;
            }
        }
        Debug.Log(numOfthisSlot);

        if (newSlotsListUp.Count < 14 - (numOfthisSlot+1) )
        {
            if (value == 5) //верхние слоты условия
            {
                thisAdd.current = isLengthUp();
                SlotParrentUp.SetActive(true);
                if (newSlotsListUp.Count == 0) //если пока ничего нет
                {
                    if (newSlotsListDown.Count == 0) //если нижний тоже нет
                    {
                        //тогда берем позиции следующего слота, но выше по игрику
                       
                        newSlot = Instantiate(example, new Vector3(Slots.transform.GetChild(numOfthisSlot + 1).transform.position.x,
                        Slots.transform.GetChild(numOfthisSlot + 1).transform.position.y + 0.7f,
                        Slots.transform.GetChild(numOfthisSlot + 1).transform.position.z),
                        Quaternion.identity, SlotParrentUp.transform);

                        newSlot.SetActive(true);
                        newSlotsListUp.Add(newSlot);

                    }
                    else
                    { //если есть нижний, то берем его позицию, но выше по игрику
                        newSlot = Instantiate(example, new Vector3(newSlotsListDown[0].transform.position.x,
                        newSlotsListDown[0].transform.position.y + 1.35f,
                        newSlotsListDown[0].transform.position.z),
                        Quaternion.identity, SlotParrentUp.transform);

                        newSlot.SetActive(true);
                        newSlotsListUp.Add(newSlot);

                    }

                }
                else //если же это не первый
                {
                    //Debug.Log(newSlot.transform.position.x);
                    //Debug.Log(Mathf.Round(newSlot.transform.position.x));

                    if (Mathf.Round(newSlotsListUp[newSlotsListUp.Count - 1].transform.position.x) == Mathf.Round(10.4143f))
                    {
                        //проверяем не на грани ли он экрана (позиции последнего слота)
                        //даем новую позицию внизу 
                        newSlot = Instantiate(example, new Vector3(1.7f, -3f, 0f),
                        Quaternion.identity, SlotParrentUp.transform);

                        newSlot.SetActive(true);
                        newSlotsListUp.Add(newSlot);

                    }
                    else
                    {   //копируем позицию последнего, и двигаем по иксу
                        newSlot = Instantiate(example, new Vector3(newSlotsListUp[newSlotsListUp.Count - 1].transform.position.x + 1.45f,
                        newSlotsListUp[newSlotsListUp.Count - 1].transform.position.y,
                        newSlotsListUp[newSlotsListUp.Count - 1].transform.position.z),
                        Quaternion.identity, SlotParrentUp.transform);

                        newSlot.SetActive(true);
                        newSlotsListUp.Add(newSlot);

                    }

                }

                //красим его в тот цвет, в который покрашен родительский
                newSlot.GetComponent<Image>().color = new Color(Slots.transform.GetChild(numOfthisSlot).transform.GetComponent<Image>().color.r, 213,
                    Slots.transform.GetChild(numOfthisSlot).transform.GetComponent<Image>().color.b,
                    255);
                

                thisAdd.current = isLengthUp();

                if (thisAdd.current > thisAdd.old) //проверяем слоты, если новый условный слот, то смещаем главные слоты
                {
                    for (int k = numOfthisSlot; k < Slots.transform.childCount; k++)
                    {
                        Slots.transform.GetChild(k + 1).position = Slots.transform.GetChild(k + 2).position;
                        if (k == 11)
                        {
                            Slots.transform.GetChild(12).position = Slots.transform.GetChild(13).position;
                            break;
                        }
                    }

                    if (z > 1)
                    {
                        Slots.transform.GetChild(z - 1).gameObject.SetActive(false);
                        z--;
                    }
                }
            }
        }

        if (newSlotsListDown.Count < 14 - (numOfthisSlot + 1))
        {
            if (value == 6) //для нижних действий
            {
                thisAdd.current = isLength();
                SlotParrentDown.SetActive(true);
                if (newSlotsListDown.Count == 0)
                {
                    if (newSlotsListUp.Count == 0) //когда нет верхнего
                    {
                        newSlot = Instantiate(example, new Vector3(Slots.transform.GetChild(numOfthisSlot + 1).transform.position.x,
                        Slots.transform.GetChild(numOfthisSlot + 1).transform.position.y - 0.7f,
                        Slots.transform.GetChild(numOfthisSlot + 1).transform.position.z),
                        Quaternion.identity, SlotParrentDown.transform);

                        newSlot.SetActive(true);
                        newSlotsListDown.Add(newSlot);
                    }
                    else//есть верхний
                    {
                        newSlot = Instantiate(example, new Vector3(newSlotsListUp[0].transform.position.x,
                        newSlotsListUp[0].transform.position.y - 1.35f,
                        newSlotsListUp[0].transform.position.z),
                        Quaternion.identity, SlotParrentDown.transform);

                        newSlot.SetActive(true);
                        newSlotsListDown.Add(newSlot);
                    }

                }
                else //есть существующие нижние
                {
                    if (Mathf.Round(newSlotsListUp[newSlotsListUp.Count - 1].transform.position.x) == Mathf.Round(10.4143f))
                    {
                        //если на грани 
                        newSlot = Instantiate(example, new Vector3(1.7f, -4.4f, 0f),
                        Quaternion.identity, SlotParrentDown.transform);

                        newSlot.SetActive(true);
                        newSlotsListDown.Add(newSlot);
                    }
                    else //если не на грани, копируем последнюю позицию
                    {
                        newSlot = Instantiate(example, new Vector3(newSlotsListDown[newSlotsListDown.Count - 1].transform.position.x + 1.45f,
                        newSlotsListDown[newSlotsListDown.Count - 1].transform.position.y,
                        newSlotsListDown[newSlotsListDown.Count - 1].transform.position.z),
                        Quaternion.identity, SlotParrentDown.transform);

                        newSlot.SetActive(true);
                        newSlotsListDown.Add(newSlot);
                    }

                    thisAdd.current = isLength();

                    if (thisAdd.current > thisAdd.old) //проверяем слоты, если новый условный слот, то смещаем главные слоты
                    {
                        for (int k = numOfthisSlot; k < Slots.transform.childCount; k++)
                        {
                            Slots.transform.GetChild(k + 1).position = Slots.transform.GetChild(k + 2).position;
                            if (k == 11)
                            {
                                Slots.transform.GetChild(12).position = Slots.transform.GetChild(13).position;
                                break;
                            }
                        }

                        if (z > 1)
                        {
                            Slots.transform.GetChild(z - 1).gameObject.SetActive(false);
                            z--;
                        }
                    }
                }
                newSlot.GetComponent<Image>().color = new Color(Slots.transform.GetChild(numOfthisSlot).transform.GetComponent<Image>().color.r, 213,
                   Slots.transform.GetChild(numOfthisSlot).transform.GetComponent<Image>().color.b,
                   255);
            }
        }
        
    }

    public class CheckLength
    {
        public int current;
        public int old;
    }

    private int isLength()
    {
        return newSlotsListDown.Count - newSlotsListUp.Count;
    }
    private int isLengthUp()
    {
        return newSlotsListUp.Count - newSlotsListDown.Count;
    }
    public void onClickDelete(int value)
    {
        /*if (value == 5)
        {
            var thisCheck = new CheckLength();
            
            if (newSlotsListUp.Count != 0)
            {
                Destroy(newSlotsListUp[newSlotsListUp.Count - 1].gameObject);
                CheckLenght(thisCheck);
                SortSlots(thisCheck.who);
            }

        } else if( value == 6)
        {
            var thisCheck = new CheckLength();

            if (newSlotsListUp.Count != 0)
            {
                Destroy(newSlotsListUp[newSlotsListUp.Count - 1].gameObject);
                CheckLenght(thisCheck);
                SortSlots(thisCheck.who);
            }
        }*/
    }

    

    private void SortSlots(string str)
    {
        if (str == "no")
        {
            for (int k = 0; k < Slots.transform.childCount; k++)
            {
                Slots.transform.GetChild(k + 2).position = Slots.transform.GetChild(k + 1).position;
                if (k == 11)
                {
                    Slots.transform.GetChild(13).position = Slots.transform.GetChild(12).position;
                    break;
                }
            }
        } 
    }
 }
