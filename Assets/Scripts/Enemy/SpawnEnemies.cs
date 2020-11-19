using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] float minSecondsBetweenSpawning = 3.0f;
    [SerializeField] float maxSecondsBetweenSpawning = 6.0f;
    [SerializeField] GameObject firstSpawn;
    [SerializeField] GameObject secondSpawn;
    [SerializeField] GameObject thirdSpawn;
    [SerializeField] int maxEnemies;

    private int number;

    //bool deviceNotBeChased = false;
    static public int numberOfActiveEnemies = 0;
    int numberOfAvalibaleDevices = 0;
    DeviceWall[] deviceWall;

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
        if (GameObject.FindGameObjectsWithTag("DeviceInPlace").Length > 0 && DeviceNotBeChased() == true
            && numberOfActiveEnemies < maxEnemies)
            {
            timeElapsed += Time.deltaTime;
            if (timeTillDeploy < timeElapsed)
            {
                MakeThingToSpawn();
                timeTillDeploy = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
                timeElapsed = 0;
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
        numberOfActiveEnemies++;
    }

    bool DeviceNotBeChased()
    {
        deviceWall = FindObjectsOfType<DeviceWall>();
        numberOfAvalibaleDevices = deviceWall.Length;
        foreach (DeviceWall device in deviceWall)
        {
            if (device.comingToThisOne)
            {
                numberOfAvalibaleDevices--;
            }
        }

        if (numberOfAvalibaleDevices > 0)
            return true;
        return false;
    }
}