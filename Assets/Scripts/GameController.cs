using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject asteroid = null;
	public Vector3 asteroidSpawn = Vector3.zero;
	public int asteroidCount = 0;
	public float asteroidSpawnWait = 0.0f;
	public float asteroidSpawnStartWait = 0.0f;
	public float asteroidWaveWait = 0.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnAsteroidWaves ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator SpawnAsteroidWaves(){
		yield return new WaitForSeconds(asteroidSpawnStartWait);
		while(true)
		{
			for(int i=0; i < asteroidCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range(-asteroidSpawn.x, asteroidSpawn.x), asteroidSpawn.y, asteroidSpawn.z);
				Instantiate (asteroid, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds(asteroidSpawnWait);
			}
			yield return new WaitForSeconds(asteroidWaveWait);
		}
	}

}
