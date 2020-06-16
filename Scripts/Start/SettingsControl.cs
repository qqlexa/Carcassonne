using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine.UI;
using UnityEngine;


public class SettingsControl : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject settingsMenu;
    public GameObject aboutMenu;

    public Slider playersSlider;
    public Slider musicSlider;

    public GameObject newGameBtn;
    public GameObject settingsBtn;
    public GameObject quitBtn;


    public float players = GlobalVariables.playerCount;


    // Start is called before the first frame update
    public void Slider_Players_Changed(float newValue)
    {
       
        players = 2 + newValue;
        GlobalVariables.playerCount = players;
    }

    public void Slider_Music_Changed(float newValue)
    {
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
            Back();
        }
    }

    public void Back()
    {
        GlobalVariables.SoundButton();

        settingsMenu.SetActive(false);

        newGameBtn.SetActive(true);
        settingsBtn.SetActive(true);
        quitBtn.SetActive(true);
        aboutMenu.SetActive(false);

        startMenu.SetActive(true);
    }


    public void About()
    {
        GlobalVariables.SoundButton();

        aboutMenu.SetActive(true);
    }

}
