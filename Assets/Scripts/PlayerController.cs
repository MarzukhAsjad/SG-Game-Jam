using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public variables
    public GameObject pointer;
    public float rotSpeed; // speed of rotation
    public float jumpForce; // force of jump
    public float thrust; // horizontal movement force
    public bool isTouchingGround; 
    public bool isTouchingCeiling;
    
    //private variables
    Rigidbody2D rb;
    Transform direction; // transform for the pointer
    float theta; // euler angle of z for pointer in degrees
    float thetaRad; // euler angle of z for pointer in radians

    // Start is called initially
    private void Start()
    {
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
        //transform.position += new Vector3(0.001f * thrust, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // if space or mouse
        {
            rb.AddForce(new Vector3(jumpForce * Mathf.Cos(thetaRad), jumpForce * Mathf.Sin(thetaRad), 0), ForceMode2D.Impulse);
        }

        // cap rotation speed 
        //Debug.Log(rb.angularVelocity);
        if (rb.angularVelocity >= 300)
        {
            rb.angularVelocity = 300;
        }
        
        if(rb.angularVelocity <= -300)
        {
            rb.angularVelocity = -300;
        }

        // cap velocity
        //Debug.Log(rb.velocity.magnitude);
    }

    private void ChangeRotation() // rotates pointer
    {
        /*
        if (isTouchingGround == true) // if touching ground
        {
            //pointer.SetActive(true);
            if (theta < 0 || theta > 90) // if on ground (0 ~ 90)
            {
                rotSpeed = -rotSpeed;
            }
        }
        
        if (isTouchingCeiling == true) // if touching ceiling
        {
            //pointer.SetActive(true);
            if (theta > 0 || theta < -90) // if on ceiling (-90 ~ 0)
            {
                rotSpeed = -rotSpeed;
            }
        }
        if (isTouchingGround == false || isTouchingCeiling == false) // if in mid-air
        {
            //pointer.SetActive(false);
        }
        */
        
        direction.RotateAround(this.transform.position, new Vector3(0, 0, -1), rotSpeed * Time.deltaTime);
    }
}
