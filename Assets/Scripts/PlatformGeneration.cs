using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] Transform centre;
    private float halfd = 17f / 2; // 17f is the hardcoded screen length
    private float halfh = 10f / 2; // 10f is the hardcoded screen height
    //private GameObject obj;
    void Start()
    {
        //centre.position = new Vector3(0, 0, 0); // setting initial position as the world's origin
        Debug.Log(halfd + " " + halfh);
        GenerateView(); // this should be finally replaced by GenerationManager()
        
    }

    void GenerationManager() // Generates 3 x 3 grid of views within the player 
    {
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                GenerateView();
            }
        }
    }
    void GenerateView() // Generates all platforms in 2 x 2 grid within camera
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                GeneratePlatform(i, j, centre);
            }
        }
    }
    void GeneratePlatform(int i, int j, Transform centre) // Generate an individual platform
    {
        int rand_height = Random.Range(0, Mathf.FloorToInt(halfh)); // height of next platform
        int rand_dist = Random.Range(0, Mathf.FloorToInt(halfd)); // distance of next platform
        
        Instantiate(platform, centre.position + new Vector3(rand_dist + halfd * i, rand_height + halfh * j, 0), Quaternion.Euler(0, 0, Random.Range(0, 90)));
        Debug.Log(centre.position + new Vector3(rand_dist + halfd * i, rand_height + halfh * j, 0));
    }
}
