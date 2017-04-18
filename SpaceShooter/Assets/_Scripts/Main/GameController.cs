using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool isGameOver;
	private bool shouldRestart;
	private int score;

	void Start()
	{
		score = 0;
		isGameOver = false;
		shouldRestart = false;
		restartText.text = string.Empty;
		gameOverText.text = string.Empty;
		UpdateScore();
		StartCoroutine(SpawnWaves());
	}

	IEnumerator SpawnWaves()
	{
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				yield return new WaitForSeconds(startWait);
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
				if (isGameOver)
				{
					restartText.text = "Press 'R' or Touch/Click for restart";
					shouldRestart = true;
					break;
				}
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}

	void Update()
	{
		if (shouldRestart)
		{
			if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Mouse0))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}

	void UpdateScore()
	{
		scoreText.text = string.Format("Score: {0}", score);
	}

	public void AddPoints(int points)
	{
		score += points;
		UpdateScore();
	}

	public void GameOver()
	{
		gameOverText.text = "GAME OVER";
		isGameOver = true;
	}
}
