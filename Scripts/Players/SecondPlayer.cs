using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondPlayer : MonoBehaviour
{
    public GameObject NamePlayer;

    public GameObject MeeplesPlayer;

    public GameObject IconPlayer;

    public GameObject ScorePlayer;

    public GameObject plusBtn;
    public GameObject minusBtn;

    // Start is called before the  frame update
    void Start()
    {
        NamePlayer.GetComponent<Text>().text = GlobalVariables.playersNames[1];

        IconPlayer.GetComponent<Image>().sprite = Resources.Load<Sprite>(GlobalVariables.playersColors[1]);


        MeeplesPlayer.GetComponent<Text>().text = GlobalVariables.playersMeeples[1].ToString();
    }

    // Update is called once per frame
    void Update()
    { // if (GlobalVariables.playerCount > 1)
        if (GlobalVariables.playerCount > 1) ScorePlayer.GetComponent<Text>().text = GlobalVariables.playersScore[1].ToString();
        if (GlobalVariables.playerCount > 1) MeeplesPlayer.GetComponent<Text>().text = GlobalVariables.playersMeeples[1].ToString();
    }
}
