using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeContrloller : MonoBehaviour
{
    private float waitTime = 1.0f;
    public float timer = 0.0f;
    private float visualTime = 0.0f;
    private int width, height;
    private float value = 10.0f;
    private float scrollBar = 1.0f;

    public Text secObj;
    public Text minObj;

    private int secs = 0;
    private int mins = 0;


    // Start is called before the first frame update
    void Start()
    {
        // Time.timeScale = scrollBar;
        secObj.text = Mathf.Round(timer).ToString() + "s";

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > secs)
        {
            if (timer > 59.9f)
            {
                timer = 0.0f;
                secs = 0;

                mins++;
                minObj.text = mins.ToString() + "m";
            }
            else
            {

                secObj.text = Mathf.Round(timer).ToString() + "s";
                secs++;

                // Time.timeScale = 0;
            }
            Time.timeScale = 1f;
        }

    }
}
