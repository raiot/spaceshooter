using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed;
	private Rigidbody rigidBody;
	void Start()
	{
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.velocity = transform.forward * speed;
	}
}
