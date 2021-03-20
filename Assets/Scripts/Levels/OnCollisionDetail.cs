using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDetail : MonoBehaviour
{
    public static bool isContact = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("Персонаж в моей территори");
            isContact = true;
            
        }
    }
    
}
