using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void NextLevel(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }
    public static void NextLevelCopy(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }
    
}
