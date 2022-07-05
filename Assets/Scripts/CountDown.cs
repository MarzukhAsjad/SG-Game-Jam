using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public int num = 11;
    public GameObject player;

    private float startTime;
    private float currentTime;
    private float elapsedTime;
    private TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    private void Start()
    {
        num = 11;
        startTime = Time.time;
    }

    private void Update()
    {
        currentTime = Time.time;

        if (num > 0)
        {
            ChangeNumber();
        }
        else
        {
            player.GetComponent<PlayerController>().Die();
            gameObject.SetActive(false);
        }
    }
    void ChangeNumber()
    {
        elapsedTime = currentTime - startTime;
        if (elapsedTime >= 1)
        {
            num -= 1;
            textMesh = GetComponent<TextMeshProUGUI>();
            textMesh.text = num.ToString();
            startTime = currentTime;
        }
    }
    

}
