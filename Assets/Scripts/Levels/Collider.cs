using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    public static bool isCollision = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collider collision" + isCollision);
        isCollision = true;
    }
}
