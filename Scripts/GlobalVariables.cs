using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalVariables
{
    public static int cameraMinX = 20;
    public static int cameraMinY = 640;
    public static int cameraMinZ = -2;

    public static int cameraMaxX = 50;
    public static int cameraMaxY = 675;
    public static int cameraMaxZ = -50;

    public static bool isPlaying = false;

    public static float playerCount = 2f;
    public static float music_level = 10f;

    public static List<string> playersNames = new List<string>();
    public static List<string> playersColors = new List<string>();
    public static List<int> playersMeeples = new List<int>();
    public static List<int> playersScore = new List<int>();


    public static int countCards = 84;
    public static int curCards = 84;

    public static string curPlayer = "Player1";
    public static string curCard = "0";
    public static int curPlayerIndex = 0;

    public static bool setMeeple;
    //                    0  1  2  3  4  5  6  7  8  9  10, RIVER
    // int[] countTiles = {4, 5, 1, 3, 3, 2, 2, 2, 3, 1, 1, 2, 2, 2, 1, 1, 2, 8, 9, 4, 1, 4, 3, 3, 3, 3, 2, 1, 2, 1, 1, 1, 1}; 


    public static void SoundButton()
    {
        if (GlobalVariables.isPlaying)
        {
            GameObject.FindGameObjectWithTag("SoundBtn").GetComponent<ButtonSound>().Play();
            GameObject.FindGameObjectWithTag("SoundBtn").GetComponent<ButtonSound>().SetVolume(GlobalVariables.music_level);
        }
    }
}
