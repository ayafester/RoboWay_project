using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenDoor : MonoBehaviour
{
    Animation animDoor;
    public static bool isDoorOpen;
    public GameObject player;
   
    public Sprite zad; //спрайты для анимации
    public Sprite pered;
    public Sprite legZad;
    public Sprite legPered;

    private Animation anim;
    private Rigidbody2D rb; //компоненты персонажа

    void Start()
    {
        animDoor = GetComponent<Animation>();
        anim = player.GetComponent<Animation>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animDoor.Play("OpenDoor");
        isDoorOpen = true;
        StartCoroutine(moveObjectRightUp());
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

        Debug.Log("ухожу в закат" + Collider.isCollision + ChangeConditionToBlock.isContact);
        Vector3 end = new Vector3(-2.73f, -4.12f, -13.8f);
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

}
