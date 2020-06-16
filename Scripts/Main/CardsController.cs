using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsController : MonoBehaviour
{
    public Text countCards;
    public Text curPlayer;
    public Image curCard;

    private int card;
    private string player;

    void Start()
    {
        player = "";
        card = GlobalVariables.curCards;
    }

    // Update is called once per frame
    void Update()
    {
        if (card != GlobalVariables.curCards)
        {
            countCards.text = "x" + GlobalVariables.curCards.ToString();
            curPlayer.text = GlobalVariables.curPlayer;
            curCard.sprite = Resources.Load<Sprite>(GlobalVariables.curCard.ToString());
            player = GlobalVariables.curPlayer;
        }
    }
}
