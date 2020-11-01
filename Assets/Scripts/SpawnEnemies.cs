using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public GameObject spawnPrefab;

	public float minSecondsBetweenSpawning = 3.0f;
	public float maxSecondsBetweenSpawning = 6.0f;
	
	private float timeElapsed;
	private float timeTillDeploy;

	// Use this for initialization
	void Start () {
		timeTillDeploy = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
	}

	// Update is called once per frame
	void Update()
	{
		timeElapsed += Time.deltaTime;
			if (timeTillDeploy < timeElapsed)
			{
				MakeThingToSpawn();
				timeTillDeploy = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
				timeElapsed = 0;
			}		
	}

	void MakeThingToSpawn()
	{
		GameObject clone = Instantiate(spawnPrefab, transform.position, transform.rotation) as GameObject;
	}
}
