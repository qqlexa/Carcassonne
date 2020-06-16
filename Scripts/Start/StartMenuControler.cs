using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuControler : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject settingsMenu;
    public GameObject newGameBtn;
    public GameObject settingsBtn;
    public GameObject quitBtn;

    public Slider playersSlider;
    public Slider musicSlider;

    void Start()
    {
        settingsMenu.SetActive(false);
        
        playersSlider.value = GlobalVariables.playerCount - 2;
        musicSlider.value = GlobalVariables.music_level * 10;

        // GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().PlayMusic();
    }

    void Update()
    {

    }

    public void Settings()
    {
        GlobalVariables.SoundButton();
        newGameBtn.SetActive(false);
        settingsBtn.SetActive(false);
        quitBtn.SetActive(false);

        settingsMenu.SetActive(true);
        // startMenu.SetActive(false);
    }

    public void NewGame()
    {
        GlobalVariables.SoundButton();
        SceneManager.LoadScene("NewGameMenu");
    }

    public void Quit()
    {
        GlobalVariables.SoundButton();
        Application.Quit();
    }

}
