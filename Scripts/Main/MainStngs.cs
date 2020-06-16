using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

using UnityEngine.UI;
using UnityEngine;

public class MainStngs : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;


    public GameObject resumeBtn;
    public GameObject quitBtn;


    public void Slider_Music_Changed(float newValue)
    {
        GlobalVariables.SoundButton();
        if (GlobalVariables.music_level != newValue && GlobalVariables.isPlaying)
        {
            GlobalVariables.music_level = newValue / 10;
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().SetVolume(GlobalVariables.music_level);
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Resume();
        }

        if (Input.GetKey(KeyCode.Return))
        {
            Resume();
        }
    }

    public void Resume()
    {
        settingsMenu.SetActive(false);
    }

    public void Quit()
    {
        GlobalVariables.SoundButton();
        Application.Quit();
    }

}
