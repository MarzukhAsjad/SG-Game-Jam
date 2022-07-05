using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour
{
    public float interval = 5.0f;
    public GameObject Generator; // missile generator
    public GameObject missile; // missile prefab

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InvokeRepeating("Blink", 0, 2.0f);
            InvokeRepeating("GenerateMissile", 0, interval);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke();
    }

    void GenerateMissile()
    {
        Instantiate(missile, Generator.transform.position, Quaternion.identity);
    }

    void Blink()
    {
        sprite.enabled = true;
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.0f);
        sprite.enabled = false;
    }

}
