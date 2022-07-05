using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject MainMenu;
    public void Back()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
