using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewMenu: MonoBehaviour
{

    public void Quit()
    {
        if (GlobalVariables.isPlaying)
        {
            GameObject.FindGameObjectWithTag("SoundBtn").GetComponent<ButtonSound>().Play();
            GameObject.FindGameObjectWithTag("SoundBtn").GetComponent<ButtonSound>().SetVolume(GlobalVariables.music_level);
        }

        Application.Quit();
    }

}
