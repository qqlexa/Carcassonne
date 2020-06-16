using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class About : MonoBehaviour
{
    public GameObject aboutMenu;


    public void Back()
    {
        GlobalVariables.SoundButton();
        aboutMenu.SetActive(false);
    }

}
