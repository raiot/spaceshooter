using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
	private float SPEED = 10f;
	private float TILT = 5f;
	Rigidbody rigidBody;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private AudioSource audio;

	private float nextFire;

	void Start()
	{
		rigidBody = GetComponent<Rigidbody>();
		audio = GetComponent<AudioSource>();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		Vector3 constraints = new Vector3
			(
				Mathf.Clamp(rigidBody.position.x, boundary.GetXMin(), boundary.GetXMax()),
				0.0f,
				Mathf.Clamp(rigidBody.position.z, boundary.GetZMin(), boundary.GetZMax())
			);
		rigidBody.velocity = movement * SPEED;
		rigidBody.position = constraints;
		rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, (-1 * TILT * rigidBody.velocity.x));

	}

	void Update()
	{
		bool isFirePressed = Input.GetButton("Fire1");
		if (isFirePressed && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play();
		}
	}
}
