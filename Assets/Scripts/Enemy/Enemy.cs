using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform destination;
    //[SerializeField] float speed = 2f;
    public GameObject target;
    NavMeshAgent navMeshAGent;
    [SerializeField]
    Animator animatior;
    BoxCollider boxCollider;
    public bool destroy = false;
    TimedAction timer;
    Enemy enemy;
    DeviceWall deviceWall;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        timer = gameObject.AddComponent<TimedAction>();
        boxCollider = GetComponent<BoxCollider>();
        target = FindDeviceToChase();
        navMeshAGent = this.GetComponent<NavMeshAgent>();

        if (target == null) return;

        deviceWall = target.GetComponent<DeviceWall>();
        SetDestination(target.transform);
    }

    void Update()
    {
        deviceWall.comingToThisOne = true;
        try
        {
            if (target.gameObject.CompareTag("DeviceInPlace")) return;
            ChaseNewTarget();
        }
        catch (NullReferenceException)
        {
            DisableEnemy();
        }    
    }
    private void ChaseNewTarget()
    {
        target = FindDeviceToChase();
        if (target != null)
        {
            deviceWall = target.GetComponent<DeviceWall>();
            SetDestination(target.transform);
        }
    }

    private void SetDestination(Transform newDestination)
    {
        destination = newDestination;       
        if (destination != null)
        {
            Vector3 targerVector = destination.position;
            transform.LookAt(targerVector);
            navMeshAGent.SetDestination(targerVector);
        }    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var enemyTargetWall = target.GetComponent<DeviceWall>();
            enemyTargetWall.PlayerCollidedWithEnemy();
            DisableEnemy();      
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeviceInPlace") && other.gameObject == target)
        {
            animatior.SetBool("IsStanding", true);
            navMeshAGent.SetDestination(gameObject.transform.position);       
        }
    }
    public GameObject FindDeviceToChase()
    {
        GameObject[] placedDevices = GameObject.FindGameObjectsWithTag("DeviceInPlace");      
        int i = 0;
        int brojac, m =0;
        if (placedDevices.Length != 0)
        {           
            for (int j = 0; j < placedDevices.Length; j++)
            {
                if (placedDevices[j].GetComponent<DeviceWall>().comingToThisOne == false)
                {
                    m++;
                }              
            }
            if (m == 0)
            {
                return null;
            }
            GameObject[] devicesNotChased = new GameObject[m];
            for (int j = 0; j < placedDevices.Length; j++)
            {
                if (placedDevices[j].GetComponent<DeviceWall>().comingToThisOne == false)
                {
                    devicesNotChased[i++] = placedDevices[j];
                }
            }
            brojac = UnityEngine.Random.Range(0, m);
            GameObject pickedDevice = devicesNotChased[brojac];
            pickedDevice.GetComponent<DeviceWall>().comingToThisOne = true;
            return pickedDevice;
        }
        else return null;
    }
    public void DestroyCrab()
    {
        Destroy(gameObject);
    }
   public void DisableEnemy()
    {
        SpawnEnemies.numberOfActiveEnemies--;
        SetDestination(gameObject.transform);
        animatior.SetBool("IsDestroy", true);
        boxCollider.enabled = false;
        timer.StartTimedAction(DestroyCrab, 2.9f);
        enemy.enabled = false;   
    }
}