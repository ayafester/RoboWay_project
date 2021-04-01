using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeConditionToBlock : MonoBehaviour
{
   
    public static bool isContact = false;
    public Sprite block;
    private PolygonCollider2D coolider;
    private SpriteRenderer spriteRend;
    void Start()
    {
        coolider = GetComponent<PolygonCollider2D>();
        spriteRend = GetComponent<SpriteRenderer>();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            coolider.isTrigger = false;
            spriteRend.sprite = block;
            spriteRend.sortingLayerID = 0;
            //isContact = true;
        }
    }
    
}
