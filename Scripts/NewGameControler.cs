using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameControler : MonoBehaviour
{
    public GameObject menuPanel;

    public GameObject redBtn;
    public GameObject greenBtn;
    public GameObject whiteBtn;
    public GameObject yellowBtn;
    public GameObject magentaBtn;

    public float playerCount;
    public int cur_player;

    public InputField playerName;

    public string selectedColor;

    void Start()
    {
        // GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().PlayMusic();
        cur_player = 1;

        playerName.text = "Player " + cur_player;
    }

        
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartMenu");
        }

    }

    private void SetMeeplesColors()
    {
        redBtn.GetComponent<Image>().color = Color.red;
        greenBtn.GetComponent<Image>().color = Color.green;
        whiteBtn.GetComponent<Image>().color = Color.white;
        yellowBtn.GetComponent<Image>().color = Color.yellow;
        magentaBtn.GetComponent<Image>().color = Color.magenta;
    }

    public void SetMeeple(string color)
    {
        GlobalVariables.SoundButton();
        selectedColor = color;

        redBtn.GetComponent<Image>().color = Color.gray;
        greenBtn.GetComponent<Image>().color = Color.gray;
        whiteBtn.GetComponent<Image>().color = Color.gray;
        yellowBtn.GetComponent<Image>().color = Color.gray;
        magentaBtn.GetComponent<Image>().color = Color.gray;

        switch (selectedColor)
        {
            case "red":
                redBtn.GetComponent<Image>().color = Color.red;
                break;
            case "green":
                greenBtn.GetComponent<Image>().color = Color.green;
                break;
            case "white":
                whiteBtn.GetComponent<Image>().color = Color.white;
                break;
            case "yellow":
                yellowBtn.GetComponent<Image>().color = Color.yellow;
                break;
            case "magenta":
                magentaBtn.GetComponent<Image>().color = Color.magenta;
                break;
        }

        playerCount = GlobalVariables.playerCount;

    }

    public void TextChanged(string newText)
    {
        
    }

    public void Continue()
    {
        GlobalVariables.SoundButton();

        switch (selectedColor)
        {
            case "red":
                redBtn.SetActive(false);
                break;
            case "green":
                greenBtn.SetActive(false);
                break;
            case "white":
                whiteBtn.SetActive(false);
                break;
            case "yellow":
                yellowBtn.SetActive(false);
                break;
            case "magenta":
                magentaBtn.SetActive(false);
                break;
            default:
                string selected_color = "red";
                string[] colors = { "red", "green", "white", "yellow", "magenta" };
                GameObject[] buttons = { redBtn, greenBtn, whiteBtn, yellowBtn, magentaBtn };

                int i = 0;
                foreach (string color in colors)
                {
                    bool isColors = false;
                    foreach (string colorList in GlobalVariables.playersColors)
                    {
                        if (color == colorList)
                        {
                            isColors = true;
                            break;
                        }
                    }

                    if (!isColors)
                    {
                        selectedColor = color;
                        buttons[i].SetActive(false);
                        break;
                    }

                    i++;
                }
                break;
        }

        GlobalVariables.playersNames.Add(playerName.text);
        GlobalVariables.playersColors.Add(selectedColor);
        GlobalVariables.playersMeeples.Add(7);
        GlobalVariables.playersScore.Add(0);
        selectedColor = "";
        
        SetMeeplesColors();

        cur_player++;

        if (cur_player > GlobalVariables.playerCount)
        {
            GlobalVariables.curPlayer = GlobalVariables.playersNames[0];
            GlobalVariables.curCard = "BackSideCardCarcassonne";
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            playerName.text = "Player " + cur_player;
        }
    }

    public void Quit()
    {
        GlobalVariables.SoundButton();
        Application.Quit();
    }

}
