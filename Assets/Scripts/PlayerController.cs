using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //public variables
    public GameObject pointer;
    public GameObject grounds;
    public GameObject MainMenu;
    public GameObject deathMenu;

    public float rotSpeed; // speed of rotation
    public float jumpForce; // force of jump
    public float thrust; // horizontal movement force
    //private variables
    Rigidbody2D rb;
    Transform direction; // transform for the pointer
    float theta; // euler angle of z for pointer in degrees
    float thetaRad; // euler angle of z for pointer in radians

    // Start is called initially
    private void Start()
    {
        Time.timeScale = 1.0f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        direction = pointer.GetComponent<Transform>();
        theta = direction.rotation.eulerAngles.z;
        thetaRad = theta * Mathf.PI / 180;
        ChangeRotation();
        PlayerMove();        
    }

    private void PlayerMove() // code to move player
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // if space or mouse is clicked
        {
            rb.AddForce(new Vector3(jumpForce * Mathf.Cos(thetaRad), jumpForce * Mathf.Sin(thetaRad), 0), ForceMode2D.Impulse);
        }

        // cap rotation speed 
        if (rb.angularVelocity >= 300)
        {
            rb.angularVelocity = 300;
        }
        
        if(rb.angularVelocity <= -300)
        {
            rb.angularVelocity = -300;
        }

        // cap velocity
        Debug.Log(rb.velocity.magnitude);
    }
    private void ChangeRotation() // rotates pointer
    {     
        direction.RotateAround(this.transform.position, new Vector3(0, 0, -1), rotSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (grounds.GetComponent<PlatformManager>().evadeActive == true)
            {
                Die();
            }
        }
    }
    public void Die()
    {
        deathMenu.SetActive(true);
        Time.timeScale = 0.1f;
        StartCoroutine("Delay");
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(0);
    }

}
