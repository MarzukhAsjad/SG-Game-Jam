using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] Transform pivot;
    private float halfd = 17f / 2; // 17f is the hardcoded screen length
    private float halfh = 10f / 2; // 10f is the hardcoded screen height
    //private GameObject obj;
    void Start()
    {
        //pivot.position = new Vector3(0, 0, 0); // setting initial position as the world's origin
        Debug.Log(halfd + " " + halfh);
        GenerationManager(); // this should be finally replaced by GenerationManager()
        
    }

    void GenerationManager() // Generates 3 x 3 grid of views within the player 
    {
        // store pivot's y
        float old_y = pivot.transform.position.y;
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                pivot.transform.position += new Vector3(halfd * 2 * i, halfd * 2 * j, 0);
                GenerateView();
            }
            // restore pivot's y
        }
        
    }
    void GenerateView() // Generates all platforms in 2 x 2 grid within camera
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                GeneratePlatform(i, j, pivot);
            }
        }

        // if two platforms collider, destroy one of them or maybe no need of this

    }
    void GeneratePlatform(int i, int j, Transform pivot) // Generate an individual platform
    {
        int rand_height = Random.Range(0, Mathf.FloorToInt(halfh)); // height of next platform
        int rand_dist = Random.Range(0, Mathf.FloorToInt(halfd)); // distance of next platform
        
        Instantiate(platform, pivot.position + new Vector3(rand_dist + halfd * i, rand_height + halfh * j, 0), Quaternion.Euler(0, 0, Random.Range(0, 90)));
        Debug.Log(pivot.position + new Vector3(rand_dist + halfd * i, rand_height + halfh * j, 0));
    }
}
