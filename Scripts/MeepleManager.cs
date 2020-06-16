using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeepleManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Image curImg;
    public Sprite m_Sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseEnter()
    {
        curImg.sprite = m_Sprite;
    }

    public void OnMouseExit()
    {
        curImg.sprite = m_Sprite;
    }

}
