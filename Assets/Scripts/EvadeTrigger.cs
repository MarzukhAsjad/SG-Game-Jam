using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeTrigger : MonoBehaviour
{
    public GameObject grounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            grounds.GetComponent<PlatformManager>().evadeActive = true;
            StartCoroutine("Delay");
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5.0f);
        grounds.GetComponent<PlatformManager>().evadeActive = false;
    }
}
