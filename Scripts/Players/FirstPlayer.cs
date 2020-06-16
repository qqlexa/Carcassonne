using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPlayer : MonoBehaviour
{
    public GameObject firstNamePlayer;

    public GameObject firstMeeplesPlayer;

    public GameObject firstIconPlayer;

    public GameObject firstScorePlayer;

    public GameObject plusBtn;
    public GameObject minusBtn;


    // Start is called before the first frame update
    void Start()
    {
        firstNamePlayer.GetComponent<Text>().text = GlobalVariables.playersNames[0];

        firstIconPlayer.GetComponent<Image>().sprite = Resources.Load<Sprite>(GlobalVariables.playersColors[0]);


        firstMeeplesPlayer.GetComponent<Text>().text = GlobalVariables.playersMeeples[0].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.playerCount > 0) firstScorePlayer.GetComponent<Text>().text = GlobalVariables.playersScore[0].ToString();
        if (GlobalVariables.playerCount > 0) firstMeeplesPlayer.GetComponent<Text>().text = GlobalVariables.playersMeeples[0].ToString();
    }
}
