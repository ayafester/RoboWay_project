using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDetail : MonoBehaviour
{
    public static bool isContact = false;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("Персонаж в моей территори");
            isContact = true;

        }
    }
}
