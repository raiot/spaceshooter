using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		else
		{
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Shot" || other.tag == "Player")
		{
			Destroy(other.gameObject); //Destroys the collider (laser)
			Destroy(gameObject); //Destroys the object that has the script attached
			if (other.tag == "Player")
			{
				Instantiate(playerExplosion, transform.position, transform.rotation);
				gameController.GameOver();
			}
			else
			{
				Instantiate(explosion, transform.position, transform.rotation);
				gameController.AddPoints(scoreValue);
			}
		}
	}
}
