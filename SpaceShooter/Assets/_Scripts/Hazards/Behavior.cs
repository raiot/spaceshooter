using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
	public float Tumble;
	private Rigidbody asteroid;

	void Start()
	{
		asteroid = GetComponent<Rigidbody>();
		asteroid.angularVelocity = Random.insideUnitSphere * Tumble;
	}
}
