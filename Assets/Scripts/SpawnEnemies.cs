using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public GameObject spawnPrefab;

	public float minSecondsBetweenSpawning = 3.0f;
	public float maxSecondsBetweenSpawning = 6.0f;
	
	[SerializeField]
	GameObject firstSpawn;
	[SerializeField]
	GameObject secondSpawn;
	[SerializeField]
	GameObject thirdSpawn;
	private int number;
	
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
		number = Random.Range(0, 3);
		if (number == 0)
			Instantiate<GameObject>(spawnPrefab, firstSpawn.gameObject.transform.position, transform.rotation);			
		if (number == 1)
			Instantiate<GameObject>(spawnPrefab, secondSpawn.gameObject.transform.position, transform.rotation);
		if (number == 2)
			Instantiate<GameObject>(spawnPrefab, thirdSpawn.gameObject.transform.position, transform.rotation);
	}
}
