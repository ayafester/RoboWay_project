using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using System.Timers;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public GameObject blockPanel;

    public Button inputNum;
    private int numOfFunc = 1;

    public int block;
    public int level;
    public int bestCommand;

    public static bool isIfActive = false;

    private string levelName;

    public GameObject unk;

    public Sprite zad; //спрайты для анимации
    public Sprite pered;
    public Sprite legZad;
    public Sprite legPered;

    //контроль действий
    //private bool isDestroyDetail = false;

    //контроль результатов
    public GameObject Again; //панель снова изза детали
    public GameObject ResultPanel;//панель с результатами

    //private float speed = 1; //скорость движения
    private float _speedOfMove = 1f;//скорость вызова функций для инвока
    private Vector3 margin;//расстояние прохождения

    public GameObject player; // персонаж
    public GameObject det;// деталь

    public GameObject slots;//слот родитель
    public List<Transform> slotsList;//массив слотов
    private int slotsCount;//количество слотов

    public GameObject Condition;

    public GameObject ifSlotsPlus;
    public List<Transform> ifSlotsListPlus;//массив слотов

    public GameObject ifSlotsMinus;
    public List<Transform> ifSlotsListMinus;//массив слотов


    public Button okeyButton;//кнопка ок
    public int counter; //сколько сделал шагов персонаж, чтобы вывести в результат

    public int counterCommand;//сколько сделал комманд

    private Rigidbody2D rb; //компоненты персонажа
    private Animation anim;

    int lastSlot;
    bool isLast;

    private void Start()
    {
        if(block == 3)
        {
            isIfActive = false;
        }
        blockPanel.SetActive(false);
        Collider.isCollision = false;
        OpenDoor.isDoorOpen = false;
        isLast = false;

        levelName = block.ToString() + level.ToString();

        if (PlayerPrefs.GetInt("LevelName" + levelName) == 0)
        {
            PlayerPrefs.SetInt("LevelName" + levelName, 0);
        }
        rb = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animation>();

        //isDestroyDetail = false; //говорим, что деталь не взяли
         //запоминаем начальную позицию

        margin.x = 1.36f; //расстояние для шагов по х у
        margin.y = 0.97f;
        margin.z = -13.8f;//позиция по у

        slotsCount = slots.transform.childCount; //количество слотов

        for (int i = 0; i < slotsCount; i++)
        {
            slotsList.Add(slots.transform.GetChild(i)); //инициализация слотов
        }

        if (ifSlotsPlus != null)
        {
            for (int k = 0; k < ifSlotsPlus.transform.childCount; k++)
            {
                ifSlotsListPlus.Add(ifSlotsPlus.transform.GetChild(k)); //инициализация слотов ифа плюсов
            }
        }
        if (ifSlotsMinus != null)
        {
            for (int k = 0; k < ifSlotsMinus.transform.childCount; k++)
            {
                ifSlotsListMinus.Add(ifSlotsMinus.transform.GetChild(k)); //инициализация слотов ифа минусов
            }
        }
        Button btn = okeyButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);//присваиваем вызов по кнопке
    }

    private void TaskOnClick() //кнопка поехали
    {

        for (int i = 0; i < 14; i++)//проходим по массиву слотов
        {
            StartCoroutine(Step(slotsList, i, _speedOfMove));//вызываем шаг со скоростью 
        }
        okeyButton.interactable = false; //делаем кнопку недоступной
        blockPanel.SetActive(true);
        if(isIfActive) //когда работаем с ифом
        {
            if (level == 1)
            {
                Debug.Log("if" + level);
                Invoke("checkDetail", _speedOfMove + 5);
            } else if (level == 2)
            {
                Debug.Log("if"  + level);
                Invoke("checkDetail", _speedOfMove + 4);
            } else if (level == 3)
            {
                Debug.Log("if" + level);
                Invoke("checkDetail", _speedOfMove + 7);
            }
            else if (level == 4)
            {
                Debug.Log("if" + level);
                Invoke("checkDetail", _speedOfMove + 4);
            }
            else if (level == 5)
            {
                Debug.Log("if" + level);
                Invoke("checkDetail", _speedOfMove + 9);
            }

        } else
        {
            if (block == 1)
            {
                Debug.Log("Это 1 блок");
                Invoke("checkDetail", _speedOfMove + 1);
            } else if(block == 3)
            {
                Debug.Log("Это 3 блок");
                Invoke("checkDetail", _speedOfMove - 2);
            }
            
        }
        Collider.isCollision = false;
        OpenDoor.isDoorOpen = false;
        //isDestroyDetail = false;
        isLast = false;
    }

    private void checkDetail()
    {
        StopAllCoroutines();
        CancelInvoke();

        Debug.Log("check det");

        if (level == 1 && block == 1)
        {
            /*for (int i = 0; i < slotsCount; i++)
            {
                if (slotsList[i].childCount == 2)
                {
                    lastSlot = i;
                }
            }

            if (slotsList[lastSlot + 1].childCount == 2)
            {
                isLast = false; //значит, что тэйк не последний элемент
            }
            */
            isLast = true;

            if (OpenDoor.isDoorOpen == true && isLast == true)
            {
                Result();
            }
            else
            {
                Again.SetActive(true);
            }
        } else if(block == 2 || block == 3 || block == 1)
        {
            for(int i = 0; i< slotsCount; i++)
            {
                if(slotsList[i].childCount > 1)
                {
                    if (slotsList[i].GetChild(1).tag == "take")
                    {
                        isLast = isEndAction();
                    }
                }
            }
            
            Debug.Log(OnCollisionDetail.isContact + " isDestroy");
            Debug.Log(isLast);

            if (OnCollisionDetail.isContact == true && isLast == true)
            {
                Result();
            }
            else
            {
                Again.SetActive(true);
            }
        }

    }

    IEnumerator Step(List<Transform> list, int num, float speed) //один шаг в одном слоте 
    {
        if (list[num].childCount > 1)//если в слоте больше одного ребенка, то (значит там есть действие)
        {
            _speedOfMove += 2;
            if (list[num].GetChild(1).tag == "LeftDown") //если тег налево, то вызов функции шаг налево
            {
                yield return new WaitForSeconds(speed);
                StartCoroutine(moveObjectLeftDown());
                counter++;
            }
            else if (list[num].GetChild(1).tag == "LeftUp")
            {
                yield return new WaitForSeconds(speed);
                StartCoroutine(moveObjectLeftUp());
                counter++;
            }
            else if (list[num].GetChild(1).tag == "RightUp")
            {

                yield return new WaitForSeconds(speed);
                StartCoroutine(moveObjectRightUp());
                counter++;
            }
            else if (list[num].GetChild(1).tag == "RightDown")
            {

                yield return new WaitForSeconds(speed);
                StartCoroutine(moveObjectRightDown());
                counter++;
            }
            else if (list[num].GetChild(1).tag == "take")
            {

                yield return new WaitForSeconds(speed);
                //Take();

            }
            else if (list[num].GetChild(1).tag == "if")
            {
                yield return new WaitForSeconds(speed);
                StartCoroutine(IfFunc());
                //isIfActive = true;
            }
            else if (list[num].GetChild(1).tag == "func")
            {
                //yield return new WaitForSeconds(speed);

                if (numOfFunc != 0)
                {
                    Debug.Log("началась функция");

                    for (int k = 0; k < numOfFunc; k++)
                    {
                        for (int i = 0; i < ifSlotsListPlus.Count; i++)
                        {
                            StartCoroutine(Step(ifSlotsListPlus, i, _speedOfMove));
                        }
                    }

                }
            }
        }
        ChangeConditionToBlock.isIf = false;
    }
    
    public IEnumerator IfFunc()
    {
        Debug.Log("if");
        if (Condition.transform.GetChild(3).childCount > 0) //если слот условия не пустой
        {
            Debug.Log(ChangeConditionToBlock.isIf + " isif");

            if (unk.tag == "WallWood" && ChangeConditionToBlock.isIf == true) //если совпадают тэги в условии и тег стены
            {
                Debug.Log("подошел по условиям");

                for (int i = 0; i < ifSlotsListPlus.Count; i++)
                {
                    Debug.Log("куротину внизу должна начаться");
                    StartCoroutine(Step(ifSlotsListPlus, i, _speedOfMove - 5));
                    
                }

            } else if(unk.tag == "Pole")
            {
                for (int i = 0; i < ifSlotsListMinus.Count; i++)
                {
                    Debug.Log("куротину внизу должна начаться");
                    StartCoroutine(Step(ifSlotsListMinus, i, _speedOfMove - 5));
                    
                }
            }
        }
        
        yield return null;

    }

    private bool isEndAction()
    {
        for (int i = 0; i < slotsCount; i++)
        {
            if (slotsList[i].GetChild(1).tag == "take")
            {
                lastSlot = i;
                Debug.Log(lastSlot);
                if(lastSlot != 0)
                {
                    break;
                }
                
            }
        }

        if (slotsList[lastSlot + 1].childCount == 2)
        {
            Debug.Log(lastSlot + 1 + " Это следующий элемент от тейка и он не пустой");
            return false;
        }
        else return true;
        
    }
    /*void Take()
    {
        isLast = isEndAction();

        Debug.Log("take " + isLast);

        if (OnCollisionDetail.isContact == true && isLast == true)
        {
            Debug.Log(isLast + " " + lastSlot);

            Destroy(det);
            isDestroyDetail = true;

            StopAllCoroutines();
            CancelInvoke();

            Result();
        }
    }*/

    void Result()
    {
        ResultPanel.SetActive(true); //вызываем панель итога

        for (int i = 0; i < slotsCount; i++)
        {
            if (slotsList[i].childCount == 2)
            {
                counterCommand++; //считаем количество команд
            }
        }

        Text textCommand = GameObject.Find("NumberCommand").GetComponent<Text>();
        textCommand.text = counterCommand.ToString();

        PlayerPrefs.SetInt("LevelName" + levelName, 1);
        PlayerPrefs.SetInt("BestCommand" + levelName, bestCommand);
        PlayerPrefs.SetInt("CounterCommand" + levelName, counterCommand);
    }

    private void Update()
    {
        if(block == 3)
        {
            if (numOfFunc == 1)
            {

                inputNum.transform.GetChild(0).GetComponent<Text>().text = "1";
            }
            else if (numOfFunc == 2)
            {

                inputNum.transform.GetChild(0).GetComponent<Text>().text = "2";
            }
            else if (numOfFunc == 3)
            {

                inputNum.transform.GetChild(0).GetComponent<Text>().text = "3";
            }
            else if (numOfFunc == 4)
            {

                inputNum.transform.GetChild(0).GetComponent<Text>().text = "4";
            }
        }
        
    }
    public void SetNewNum()
    {
        numOfFunc += 1;
        if(numOfFunc == 5)
        {
            numOfFunc = 1;
        }
    }
    //корутина для плавного движения
    public IEnumerator moveObjectRightDown()
    {

        var body = player.transform.GetChild(0).gameObject;
        body.GetComponent<SpriteRenderer>().sprite = pered;

        var leg1 = player.transform.GetChild(3).gameObject;
        leg1.GetComponent<SpriteRenderer>().sprite = legPered;
        leg1.transform.localScale = new Vector3(-1.7f, 1.8f, 1f);

        var leg2 = player.transform.GetChild(4).gameObject;
        leg2.GetComponent<SpriteRenderer>().sprite = legPered;
        leg2.transform.localScale = new Vector3(-1.7f, 1.8f, 1f);

        var arm = player.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;


        anim.Play("RightDown");

        Vector3 end = new Vector3();
        end.x = player.transform.position.x + margin.x;
        end.y = player.transform.position.y - margin.y;
        end.z = margin.z;

        float totalMovementTime = 25f; //время для передвижения
        float currentMovementTime = 0f;//время которое прошло

        while (Vector3.Distance(player.transform.localPosition, end) > 0)
        {
            currentMovementTime += Time.deltaTime;
            if (Collider.isCollision == true)
            {
                Debug.Log(" Прекращаем движение, когда стена стала тру");
                checkDetail();
                break;
            }
            rb.position = Vector3.Lerp(player.transform.position, end, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }
    public IEnumerator moveObjectRightUp()
    {

        var body = player.transform.GetChild(0).gameObject;
        body.GetComponent<SpriteRenderer>().sprite = zad;
        body.transform.localScale = new Vector3(-1.7f, 1.8f, 1f);

        var leg1 = player.transform.GetChild(3).gameObject;
        leg1.GetComponent<SpriteRenderer>().sprite = legZad;
        leg1.transform.localScale = new Vector3(-1.7f, 1.8f, 1f);

        var leg2 = player.transform.GetChild(4).gameObject;
        leg2.GetComponent<SpriteRenderer>().sprite = legZad;
        leg2.transform.localScale = new Vector3(-1.7f, 1.8f, 1f);

        var arm = player.transform.GetChild(1).gameObject;
        arm.GetComponent<SpriteRenderer>().sortingOrder = 2;

        var arm2 = player.transform.GetChild(2).gameObject;
        arm2.GetComponent<SpriteRenderer>().sortingOrder = 0;

        anim.Play("RightUp");


        Vector3 end = new Vector3();
        end.x = player.transform.position.x + margin.x;
        end.y = player.transform.position.y + margin.y;
        end.z = margin.z;
        float totalMovementTime = 25f; //время для передвижения
        float currentMovementTime = 0f;//время которое прошло
        while (Vector3.Distance(player.transform.localPosition, end) > 0)
        {
            currentMovementTime += Time.deltaTime;
            if (Collider.isCollision == true)
            {
                Debug.Log(" Прекращаем движение, когда стена стала тру");

                checkDetail();
                break;
            }
            rb.position = Vector3.Lerp(player.transform.position, end, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }
    public IEnumerator moveObjectLeftDown()
    {

        var body = player.transform.GetChild(0).gameObject;
        body.GetComponent<SpriteRenderer>().sprite = pered;
        body.transform.localScale = new Vector3(1.7f, 1.8f, 1f);

        var leg1 = player.transform.GetChild(3).gameObject;
        leg1.GetComponent<SpriteRenderer>().sprite = legPered;
        leg1.transform.localScale = new Vector3(1.7f, 1.8f, 1f);

        var leg2 = player.transform.GetChild(4).gameObject;
        leg2.GetComponent<SpriteRenderer>().sprite = legPered;
        leg2.transform.localScale = new Vector3(1.7f, 1.8f, 1f);

        var arm = player.transform.GetChild(1).gameObject;
        arm.GetComponent<SpriteRenderer>().sortingOrder = 2;

        var arm2 = player.transform.GetChild(2).gameObject;
        arm2.GetComponent<SpriteRenderer>().sortingOrder = 0;

        anim.Play("LeftDown");
        var sprite = player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = pered;
        var sprite2 = player.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = legPered;
        var sprite3 = player.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = legPered;

        Vector3 end = new Vector3();
        end.x = player.transform.position.x - margin.x;
        end.y = player.transform.position.y - margin.y;
        end.z = margin.z;
        float totalMovementTime = 25f; //время для передвижения
        float currentMovementTime = 0f;//время которое прошло
        while (Vector3.Distance(player.transform.localPosition, end) > 0)
        {
            currentMovementTime += Time.deltaTime;
            rb.position = Vector3.Lerp(player.transform.position, end, currentMovementTime / totalMovementTime);
            if (Collider.isCollision == true)
            {
                Debug.Log(" Прекращаем движение, когда стена стала тру");

                checkDetail();
                break;
            }
            yield return null;
        }
    }

    public IEnumerator moveObjectLeftUp()
    {

        var body = player.transform.GetChild(0).gameObject;
        body.GetComponent<SpriteRenderer>().sprite = zad;
        body.transform.localScale = new Vector3(1.7f, 1.8f, 1f);

        var leg1 = player.transform.GetChild(3).gameObject;
        leg1.GetComponent<SpriteRenderer>().sprite = legZad;
        leg1.transform.localScale = new Vector3(1.7f, 1.8f, 1f);

        var leg2 = player.transform.GetChild(4).gameObject;
        leg2.GetComponent<SpriteRenderer>().sprite = legZad;
        leg2.transform.localScale = new Vector3(1.7f, 1.8f, 1f);

        var arm = player.transform.GetChild(1).gameObject;
        arm.GetComponent<SpriteRenderer>().sortingOrder = 0;

        var arm2 = player.transform.GetChild(2).gameObject;
        arm2.GetComponent<SpriteRenderer>().sortingOrder = 2;

        anim.Play("LeftUp");

        Vector3 end = new Vector3();
        end.x = player.transform.position.x - margin.x;
        end.y = player.transform.position.y + margin.y;
        end.z = margin.z;
        float totalMovementTime = 25f; //время для передвижения
        float currentMovementTime = 0f;//время которое прошло
        while (Vector3.Distance(player.transform.localPosition, end) > 0)
        {
            currentMovementTime += Time.deltaTime;
            if (Collider.isCollision == true)
            {
                Debug.Log(" Прекращаем движение, когда стена стала тру");

                checkDetail();
                break;
            }
            rb.position = Vector3.Lerp(player.transform.position, end, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }

}