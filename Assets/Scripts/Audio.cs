using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Audio : MonoBehaviour
{
    // Start is called before the first frame update
    private static Audio instance = null;
    public static AudioSource audio1;
   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this) return;
        Destroy(gameObject);
    }

    void Start()
    {
        audio1 = GetComponent<AudioSource>();
        audio1.Play();
        PlayerPrefs.SetInt("Audio", 1);
    }
    
}
