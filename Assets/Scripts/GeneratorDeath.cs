using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > 2)
        {
            Debug.Log("HIT");
            Destroy(gameObject);
        }
    }
}
