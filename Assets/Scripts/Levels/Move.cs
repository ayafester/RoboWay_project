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
    public int level;
    public GameObject unk;

    public Sprite zad; //спрайты для анимации
    public Sprite pered;
    public Sprite legZad;
    public Sprite legPered;

    //контроль действий
    private bool isDestroyDetail;
    
    //контроль результатов
    public GameObject Again; //панель снова изза детали
    public GameObject ResultPanel;//панель с результатами

    private float speed = 1; //скорость движения
    private float _speedOfMove = 1f;//скорость вызова функций для инвока
    private Vector3 margin;//расстояние прохождения

    public GameObject player; // персонаж
    public GameObject det;// деталь

    public GameObject slots;//слот родитель
    public List<Transform> slotsList;//массив слотов
    private int slotsCount;//количество слотов

    public GameObject ifSlots;
    public List<Transform> ifSlotsList;//массив слотов

    private Vector3 startPos;

    public Button okeyButton;//кнопка ок
    public float counter; //сколько сделал шагов персонаж, чтобы вывести в результат
   
    public float counterCommand;//сколько сделал комманд

    private Rigidbody2D rb; //компоненты персонажа
    private Animation anim;


    private void Start()
    {
        
        rb = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animation>();

        isDestroyDetail = false; //говорим, что деталь не взяли
        startPos = player.transform.position; //запоминаем начальную позицию
        
        margin.x = 1.36f; //расстояние для шагов по х у
        margin.y = 0.97f;
        margin.z = -13.8f;//позиция по у
       
        slotsCount = slots.transform.childCount; //количество слотов
        
        for(int i =0; i< slotsCount; i++)
        {
            slotsList.Add(slots.transform.GetChild(i)); //инициализация слотов
        }
        for (int k = 0; k < ifSlots.transform.childCount; k++)
        {
            ifSlotsList.Add(ifSlots.transform.GetChild(k)); //инициализация слотов
        }

        Button btn = okeyButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);//присваиваем вызов по кнопке
    }
   
    private void TaskOnClick() //кнопка поехали
    {
        
        for (int i=0; i<14; i++)//проходим по массиву слотов
        {
           StartCoroutine(Step(slotsList, i, _speedOfMove));//вызываем шаг со скоростью 
        }
        okeyButton.interactable = false; //делаем кнопку недоступной
        _speedOfMove += 1;
        Invoke("checkDetail", _speedOfMove); //итоговый вызов проверки деталей и шагов
        Collider.isCollision = false;
        ChangeConditionToBlock.isContact = false;
    }

    private void checkDetail()
    {
        StopAllCoroutines();

        if (level == 1)
        {
            if (OpenDoor.isDoorOpen == true)
            {
                Result();
            } else
            {
                Again.SetActive(true);
            }
        } else
        {
            if (isDestroyDetail == false)
            {
                Debug.Log("ВЫ не взяли деталь в чекдетайль");
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

                Debug.Log("Если влево вниз! Корутина должна начаться через секунд " + speed);

                yield return new WaitForSeconds(speed);


                StartCoroutine(moveObjectLeftDown());

                counter++;
            }
            else if (list[num].GetChild(1).tag == "LeftUp")
            {

                Debug.Log("Если вправо вверх! Корутина должна начаться через секунд " + speed);
                yield return new WaitForSeconds(speed);


                StartCoroutine(moveObjectLeftUp());


                counter++;
            }
            else if (list[num].GetChild(1).tag == "RightUp")
            {

                yield return new WaitForSeconds(speed);
                Debug.Log("Если вправо вверх! Корутина должна начаться через секунд " + speed);
                StartCoroutine(moveObjectRightUp());


                counter++;
            }
            else if (list[num].GetChild(1).tag == "RightDown")
            {

                yield return new WaitForSeconds(speed);
                Debug.Log("Если вправо вниз! Корутина должна начаться через секунд " + speed);
                StartCoroutine(moveObjectRightDown());


                counter++;
            }
            else if (list[num].GetChild(1).tag == "take")
            {

                yield return new WaitForSeconds(speed);

                Take();

            } else if (list[num].GetChild(1).tag == "if")
            {
                if(ifSlotsList[2].transform.GetChild(0).transform.tag == unk.tag)
                {
                    for (int i = 3; i < ifSlotsList.Count; i++)
                    {
                        StartCoroutine(Step(ifSlotsList, i, _speedOfMove));
                        //_speedOfMove += 2;
                    }
                    
                }
               
            }

        }
       
    }
    void Take()
    {
        if (OnCollisionDetail.isContact == true)
        {
            Debug.Log("деталь уничтожена ");
            Destroy(det);
            isDestroyDetail = true;
            StopAllCoroutines();
            Result();
            
        } 
    }

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
        Text textStep = GameObject.Find("NumberSteps").GetComponent<Text>(); //передаем ей компоненты
        textStep.text = counter.ToString();

        Text textCommand = GameObject.Find("NumberCommand").GetComponent<Text>();
        textCommand.text = counterCommand.ToString();
    }

   
    /*private void MoveDownLeft()
    {
        //timeStart = 240;

        for (int i = 0; i <timeStart ; i++)
        {
            Debug.Log("step");
            rb.position = Vector3.Lerp(startPosito, endPOs, progress);
            progress += step;
        }

    }

    IEnumerator ExecuteAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        Debug.Log("эта корутина началась через " + timeInSec);

        timeStart = 600;
        for (int i = 0; i < timeStart; i++)
        {
            Debug.Log("step");
            rb.position = Vector3.Lerp(startPosito, endPOs, progress);
            progress += step;
        }
        //сделать нужное
    }*/


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

        Debug.Log("корутина right down  началась");
        anim.Play("RightDown");

        Vector3 end = new Vector3();
        end.x = player.transform.position.x + margin.x;
        end.y = player.transform.position.y -margin.y;
        end.z = margin.z;

        float totalMovementTime = 25f; //время для передвижения
        float currentMovementTime = 0f;//время которое прошло

        while (Vector3.Distance(player.transform.localPosition, end) > 0)
        {
            currentMovementTime += Time.deltaTime;
            if(Collider.isCollision == true)
            {
                break;
            } else if (ChangeConditionToBlock.isContact == true)
            {
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
        
        Debug.Log("корутина right up началась");
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
                break;
            }
            if (ChangeConditionToBlock.isContact == true)
            {
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
        Debug.Log("корутина left down  началась");
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
                break;
            }
            if (ChangeConditionToBlock.isContact == true)
            {
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
        Debug.Log("корутина left up началась");
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
                break;
            }
            if (ChangeConditionToBlock.isContact == true)
            {
                break;
            }
            rb.position = Vector3.Lerp(player.transform.position, end, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }

    

    /*void MoveObjUpRight()
    {
        
        
        Vector3 pointEnd = new Vector3();
        pointEnd.x = player.transform.position.x + margin.x;
        pointEnd.y = player.transform.position.y - margin.y;
        
        Vector3 dat = new Vector3(pointEnd.x, pointEnd.y, margin.z);

        player.transform.position = Vector3.MoveTowards(player.transform.position, dat, speed);

    }*/

}
