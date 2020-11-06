using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    GameObject spawnObsticleForDevice;
    Transform destination;
    [SerializeField]
    float speed = 2f;
    private int numberOfActiveDevices;  
    bool isPlaced;   
    private float timeElapsed;
    GameObject target;
    [SerializeField]
    float timeTillDestroy;
    NavMeshAgent navMeshAGent;

    void Start()
    {
        target = FindDeviceToChase();
        if (target != null)
        {
            destination = target.transform;
            navMeshAGent = this.GetComponent<NavMeshAgent>();
            SetDestination();
        }
    }

    void Update()
    {
       if(target.gameObject.tag != "DeviceInPlace") { 
            target = FindDeviceToChase();
            if (target != null)
            {
                destination = target.transform;
                SetDestination();
            }
            else
            {
                Destroy(gameObject);
                //Instantiate<GameObject>(explosion, gameObject.transform.position, Quaternion.identity);
            }
        }
    }

    private void SetDestination()
    {
        if(destination != null)
        {
            Vector3 targerVector = destination.position;
            navMeshAGent.SetDestination(targerVector);
        }
    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
           //Instantiate<GameObject>(explosion, gameObject.transform.position, Quaternion.identity);
           Destroy(this.gameObject);
        }
        
        if (collision.gameObject.tag == "DeviceInPlace")
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= timeTillDestroy)
            {
                timeElapsed = 0;
                //Instantiate<GameObject>(explosion, gameObject.transform.position, Quaternion.identity);
                Instantiate<GameObject>(spawnObsticleForDevice, target.transform.position, Quaternion.identity);
                target.gameObject.tag = "Finish";
                Destroy(gameObject);
            }
        }
    }
    public GameObject FindDeviceToChase()
    {
        if (GameObject.FindGameObjectsWithTag("DeviceInPlace").Length != 0)
        {
            GameObject[] placedDevices;
            placedDevices = GameObject.FindGameObjectsWithTag("DeviceInPlace");
            GameObject closest;
            int brojac;
            numberOfActiveDevices = placedDevices.Length;
            brojac = Random.Range(0, numberOfActiveDevices);
            closest = placedDevices[brojac];
            return closest;
        }
        else return null;
    }
}
