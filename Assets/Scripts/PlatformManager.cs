using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public bool evadeActive = false;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat.color = Color.black;
        foreach (Transform child in transform)
        {
            randomRotate(child); // rotates the platforms randomly
        }
    }

    void randomRotate(Transform obj)
    {
        float z_rot = Random.Range(0, 180);
        obj.eulerAngles = new Vector3(0, 0, z_rot);
    }

    void Update()
    {
        if (evadeActive == true)
        {
            mat.color = Color.red;
        }
        else
        {
            mat.color = Color.black;
        }
    }
}
