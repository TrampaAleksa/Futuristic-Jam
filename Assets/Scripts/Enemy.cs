using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject spawnObsticle;
    Transform destination;
    [SerializeField]
    float speed = 2f;
    private int numberOfActiveDevices = 0;
    private Transform target;
    private bool isPlaced = false;
    private float timeElapsed;
    [SerializeField]
    float timeTillDestroy;
    NavMeshAgent navMeshAGent;
    // Start is called before the first frame update
    void Start()
    {       
        destination = FindClosestEnemy().transform;
        navMeshAGent = this.GetComponent<NavMeshAgent>();
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaced == false)
        {
            transform.LookAt(destination);
            if (destination == null)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                return;
            }
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > timeTillDestroy)
            {
                Destroy(this.gameObject);
                Instantiate<GameObject>(spawnObsticle, destination.transform.position, Quaternion.identity);
                destination.gameObject.tag = "Finish";
            }
        }
    }

    private void SetDestination()
    {
        if(destination != null)
        {
            Vector3 targerVector = destination.transform.position;
            navMeshAGent.SetDestination(targerVector);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
       
        if (collision.gameObject.tag == "Player")
            Destroy(this.gameObject);
            
        if (collision.gameObject.tag == "DeviceInPlace")
        {
            isPlaced = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
public GameObject FindClosestEnemy()
{
        
    GameObject[] placedDevices;
    placedDevices = GameObject.FindGameObjectsWithTag("DeviceInPlace");
    GameObject closest;
    int brojac;
    int i;
    numberOfActiveDevices = placedDevices.Length;
    brojac = Random.Range(0, numberOfActiveDevices);
    for (i = 0; i < brojac; i++)
    {
    }
    closest = placedDevices[i];
    return closest;
    }
}
