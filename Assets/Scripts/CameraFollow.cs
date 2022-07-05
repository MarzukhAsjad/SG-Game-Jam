using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float smoothTime = 0.5f;

    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player"); // finds the Player
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref velocity, smoothTime);
    }
}
