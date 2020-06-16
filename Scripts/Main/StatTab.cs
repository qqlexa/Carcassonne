using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTab : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void Plus(int player)
    {
        GlobalVariables.SoundButton();
        GlobalVariables.playersScore[player]++;
    }

    public void Minus(int player)
    {
        GlobalVariables.SoundButton();
        GlobalVariables.playersScore[player]--;
    }

}
