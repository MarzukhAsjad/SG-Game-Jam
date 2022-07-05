using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject tutorial;
    void Start()
    {
        Time.timeScale = 1;
        player.GetComponent<PlayerController>().enabled = false;
    }
    
    public void StartButton()
    {
        player.GetComponent<PlayerController>().enabled = true;
        gameObject.SetActive(false);
    }

    public void HelpButton()
    {
        tutorial.SetActive(true);   
        gameObject.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }


}
