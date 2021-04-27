using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
   
    public GameObject wall;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public int layer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layer == 2)
        {
            if (wall != null)
            {
                wall.GetComponent<SpriteRenderer>().sortingLayerName = "Collision";
            }
            if (wall1 != null)
            {
                wall1.GetComponent<SpriteRenderer>().sortingLayerName = "Collision";
            }
            if (wall2 != null)
            {
                wall2.GetComponent<SpriteRenderer>().sortingLayerName = "Collision";
            }
            if (wall3 != null)
            {
                wall3.GetComponent<SpriteRenderer>().sortingLayerName = "Collision";
            }
        } else
        {
            if (wall != null)
            {
                wall.GetComponent<SpriteRenderer>().sortingLayerName = "Wall";
            }
            if (wall1 != null)
            {
                wall1.GetComponent<SpriteRenderer>().sortingLayerName = "Wall";
            }
            if (wall2 != null)
            {
                wall2.GetComponent<SpriteRenderer>().sortingLayerName = "Wall";
            }
            if (wall3 != null)
            {
                wall3.GetComponent<SpriteRenderer>().sortingLayerName = "Wall";
            }
        }
            

        
    }

}
