using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    GameObject spawnPrefab;
    [SerializeField]
    float minSecondsBetweenSpawning = 3.0f;
    [SerializeField]
    float maxSecondsBetweenSpawning = 6.0f;
    [SerializeField]
    GameObject firstSpawn;
    [SerializeField]
    GameObject secondSpawn;
    [SerializeField]
    GameObject thirdSpawn;
    [SerializeField]
    int maxEnemies;
    private int number;

    private float timeElapsed;
    private float timeTillDeploy;

    // Use this for initialization
    void Start()
    {
        timeTillDeploy = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectsOfType<Enemy>().Length < maxEnemies)
        {
            timeElapsed += Time.deltaTime;
            if (timeTillDeploy < timeElapsed)
            {
                if (GameObject.FindGameObjectsWithTag("DeviceInPlace").Length > 0)
                {
                    MakeThingToSpawn();
                    timeTillDeploy = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
                    timeElapsed = 0;
                }
            }
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
