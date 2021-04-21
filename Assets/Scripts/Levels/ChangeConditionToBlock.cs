using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeConditionToBlock : MonoBehaviour
{
    public static bool isIf = false;
    public int level;
    public Sprite block;
    private SpriteRenderer spriteRend;
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            spriteRend.sprite = block;
            if (level == 1)
            {
                transform.position = new Vector3(-8.7f, 1.17f, 0f);
            }
            if(level == 3)
            {
                transform.position = new Vector3(-6.27f, -0.5f, 0f);
            }
            if (level == 5)
            {
                transform.position = new Vector3(-3.84f, -0.45f, 0f);
            }
            
            isIf = true;
            Debug.Log(isIf + " в change condition to block ");

        }
    }
}
