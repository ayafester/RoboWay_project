using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Sprite blockques;
    public GameObject wall;
    private SpriteRenderer spriteRend;
    public void NextLevel(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }
    public static void NextLevelCopy(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    public void Restart(int _sceneNumber)
    {
        Collider.isCollision = false; //говорим о том, что стена стала коллайдером
        ChangeConditionToBlock.isIf = false; //марка говорит о том, что стенка открыта
        
        SceneManager.LoadScene(_sceneNumber);

        spriteRend = wall.GetComponent<SpriteRenderer>();
        spriteRend.sprite = blockques;
    }

}
