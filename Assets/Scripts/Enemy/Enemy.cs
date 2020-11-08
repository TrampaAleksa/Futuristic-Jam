using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject spawnObsticleForDevice;
    Transform destination;
    [SerializeField] float speed = 2f;
    private int numberOfActiveDevices;
    GameObject target;
    [SerializeField] float timeTillDestroy;
    NavMeshAgent navMeshAGent;

    void Start()
    {
        target = FindDeviceToChase();

        if (target == null) return;

        navMeshAGent = this.GetComponent<NavMeshAgent>();
        SetDestination(target.transform);
    }

    void Update()
    {
        if (target.gameObject.CompareTag("DeviceInPlace")) return;

        ChaseNewTarget();
    }

    private void ChaseNewTarget()
    {
        target = FindDeviceToChase();
        if (target != null)
        {
            SetDestination(target.transform);
        }
        else
        {
            Destroy(gameObject);
            //Instantiate<GameObject>(explosion, gameObject.transform.position, Quaternion.identity);
        }
    }

    private void SetDestination(Transform newDestination)
    {
        destination = newDestination;
        
        if (destination != null)
        {
            Vector3 targerVector = destination.position;
            navMeshAGent.SetDestination(targerVector);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Instantiate<GameObject>(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("DeviceInPlace"))
        {
            gameObject.AddComponent<TimedAction>().StartTimedAction(DisableDevice, timeTillDestroy);
        }
    }

    private void DisableDevice()
    {
        //Instantiate<GameObject>(explosion, gameObject.transform.position, Quaternion.identity);
        Instantiate<GameObject>(spawnObsticleForDevice, target.transform.position, Quaternion.identity);
        target.gameObject.tag = "Finish";
        Destroy(gameObject);
    }

    public GameObject FindDeviceToChase()
    {
        GameObject[] placedDevices = GameObject.FindGameObjectsWithTag("DeviceInPlace");

        if (placedDevices.Length != 0)
        {
            int brojac = Random.Range(0, placedDevices.Length);
            GameObject randomDevice = placedDevices[brojac];
            return randomDevice;
        }
        else return null;
    }
}