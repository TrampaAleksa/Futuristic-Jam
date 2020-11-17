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
    //bool deviceNotBeChased = false;
    static public int numberOfEnemies = 0;
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
            timeElapsed += Time.deltaTime;
            if (timeTillDeploy < timeElapsed)
            {
                if (GameObject.FindGameObjectsWithTag("DeviceInPlace").Length > 0 && DeviceNotBeChased() == true 
                && FindObjectsOfType<Enemy>().Length < maxEnemies)
                {
                    MakeThingToSpawn();
                    timeTillDeploy = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
                    timeElapsed = 0;

                }
                else timeElapsed = 0;
            
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
        numberOfEnemies++;
    }
    bool DeviceNotBeChased()
    {
        if(GameObject.FindGameObjectsWithTag("DeviceInPlace").Length - numberOfEnemies > 0)
        {
            deviceWall = FindObjectsOfType<DeviceWall>();
            foreach (DeviceWall device in deviceWall)
            {
                if (device.comingToThisOne == false)
                {
                    numberOfAvalibaleDevices++;       
                }
            }
            if (numberOfAvalibaleDevices - numberOfEnemies > 0)
                return true;
            return false;
        }
        return false;
    }
}
