using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Game controller.
/// Responsible for controlling game
/// play, spawning enemies,
/// calculating score etc.
/// </summary>
public class GameController : MonoBehaviour
{
	public GameObject asteroid = null;
	public Vector3 asteroidSpawn = Vector3.zero;
	public int asteroidCount = 0;
	public float asteroidSpawnWait = 0.0f;
	public float asteroidSpawnStartWait = 0.0f;
	public float asteroidWaveWait = 0.0f;
	private int score = 0;
	public Text scoreText = null;
	public Text restartText = null;
	public Text gameOverText = null;
	private bool gameOver = false;
	private bool restart = false;

	/// <summary>
	/// Start this instance.
	/// </summary>
	private void Start ()
	{
		StartCoroutine (SpawnAsteroidWaves ());
		UpdateScore ();
		restartText.text = string.Empty;
		gameOverText.text = string.Empty;
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	private void Update ()
	{
		if (restart && Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
	
	/// <summary>
	/// Spawns the asteroid waves.
	/// </summary>
	/// <returns>The asteroid waves.</returns>
	private IEnumerator SpawnAsteroidWaves ()
	{
		yield return new WaitForSeconds (asteroidSpawnStartWait);

		while (!gameOver) {
			for (int i=0; i < asteroidCount && !gameOver; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-asteroidSpawn.x, asteroidSpawn.x), asteroidSpawn.y, asteroidSpawn.z);
				Instantiate (asteroid, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (asteroidSpawnWait);
			}
			if (!gameOver) {
				yield return new WaitForSeconds (asteroidWaveWait);
			}
		}
		restartText.text += "Restart game by pressing the 'R' key...";
		restart = true;
	}
	
	/// <summary>
	/// Updates the score.
	/// </summary>
	private void UpdateScore ()
	{
		scoreText.text = string.Format ("Score: {0:N0}", score);
	}
	
	/// <summary>
	/// Adds the score.
	/// </summary>
	/// <param name="points">Points.</param>
	public void AddScore (int points)
	{
		score += points;
		UpdateScore ();
	}
	
	/// <summary>
	/// Player destroyed handler.
	/// </summary>
	public void PlayerDestroyed ()
	{
		gameOverText.text = "Game Over Man!";
		gameOver = true;
	}
}
