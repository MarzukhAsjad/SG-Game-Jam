using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneratorCount : MonoBehaviour
{
    // Start is called before the first frame update
    public int count;
    void Start()
    {
        count = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        count = transform.childCount;
        if (count == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
