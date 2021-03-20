using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButteryLife : MonoBehaviour
{
    public int health;
    public int numberOfLives;

    public Image[] lives;
    public Sprite fullLife;
    public Sprite emptyLife;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        numberOfLives = 13;
    }

    // Update is called once per frame
    void Update()
    {

        if (health > numberOfLives)
        {
            health = numberOfLives;
        }

        for (int i = 0; i < lives.Length; i++)
        {
            if (i < health)
            {
                lives[i].sprite = fullLife;
            } else
            {
                lives[i].sprite = emptyLife;
            }
            if(i<numberOfLives)
            {
                lives[i].enabled = true;
            } else
            {
                lives[i].enabled = false ;
            }
        }
    }
}
