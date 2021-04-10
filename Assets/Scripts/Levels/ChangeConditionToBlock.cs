using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeConditionToBlock : MonoBehaviour
{
    public static bool isIf = false;
    
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
            isIf = true;
            Debug.Log(isIf + " в change condition to block ");

        }
    }
}
