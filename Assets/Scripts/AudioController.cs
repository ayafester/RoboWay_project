using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioController : MonoBehaviour
{
    public GameObject AudioButton;
    public void StopAudio()
    {
        if (PlayerPrefs.GetInt("Audio") == 1)
        {
            Audio.audio1.Stop();
            AudioButton.transform.GetChild(0).GetComponent<Text>().text = "Включить звук";
            PlayerPrefs.SetInt("Audio", 0);
            Debug.Log(false);
        }
        else
        {
            Audio.audio1.Play();
            AudioButton.transform.GetChild(0).GetComponent<Text>().text = "Выключить звук";
            PlayerPrefs.SetInt("Audio", 1);
            Debug.Log(true);
        }

    }

}
