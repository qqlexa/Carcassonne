using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FifthPlayer : MonoBehaviour
{
    public GameObject NamePlayer;

    public GameObject MeeplesPlayer;

    public GameObject IconPlayer;

    public GameObject ScorePlayer;

    public GameObject ScoreText;

    public GameObject plusBtn;
    public GameObject minusBtn;


    // Start is called before the  frame update
    void Start()
    {
        if (GlobalVariables.playerCount <= 4)
        {
            NamePlayer.SetActive(false);
            MeeplesPlayer.SetActive(false);
            IconPlayer.SetActive(false);
            ScorePlayer.SetActive(false);
            ScoreText.SetActive(false);
            plusBtn.SetActive(false);
            minusBtn.SetActive(false);
            return;
        }


        NamePlayer.GetComponent<Text>().text = GlobalVariables.playersNames[4];

        IconPlayer.GetComponent<Image>().sprite = Resources.Load<Sprite>(GlobalVariables.playersColors[4]);

        MeeplesPlayer.GetComponent<Text>().text = GlobalVariables.playersMeeples[4].ToString();
    }

    // Update is called once per frame
    void Update()
    { 
        if (GlobalVariables.playerCount > 4) ScorePlayer.GetComponent<Text>().text = GlobalVariables.playersScore[4].ToString();
        if (GlobalVariables.playerCount > 4) MeeplesPlayer.GetComponent<Text>().text = GlobalVariables.playersMeeples[4].ToString();
    }
}