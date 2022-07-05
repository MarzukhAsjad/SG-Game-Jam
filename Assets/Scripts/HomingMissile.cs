using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
	//public GameObject Explosion;
	public Transform target;
	//public GameObject deathMenu;

	public float speed = 5f;
	public float rotateSpeed = 200f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		//deathMenu = GameObject.Find("DeathMenu");
		rb = GetComponent<Rigidbody2D>();
		Destroy(gameObject, 10); // missile gets destroyed after 10 seconds

		Physics2D.IgnoreLayerCollision(7, 6); // missile ignores ground
		Physics2D.IgnoreLayerCollision(7, 8); // missile ignores all enemies

	}

	void FixedUpdate()
	{
		Vector2 direction = (Vector2)target.position - rb.position;

		direction.Normalize();

		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = -rotateAmount * rotateSpeed;

		rb.velocity = transform.up * speed;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		// Put a particle effect here
		if (coll.gameObject.tag == "Player")
		{
			//GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
			Destroy(gameObject, 0.25f);
			coll.gameObject.GetComponent<PlayerController>().Die();
			//Destroy(explosion, 1.9f);
		}
		if (coll.gameObject.tag == "Missile")
		{
			Destroy(coll.gameObject);
			Destroy(gameObject);
		}

	}
}