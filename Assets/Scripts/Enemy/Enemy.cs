using System;
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
    public GameObject target;
    [SerializeField] float timeTillDestroy;
    NavMeshAgent navMeshAGent;
    [SerializeField]
    Animator animatior;
    BoxCollider boxCollider;
    public bool destroy = false;
    TimedAction timer;
    Enemy enemy;
    GameObject deviceReference;
    DeviceWall deviceWall;
    void Start()
    {
        deviceWall = GetComponent<DeviceWall>();
        enemy = GetComponent<Enemy>();
        timer = gameObject.AddComponent<TimedAction>();
        boxCollider = GetComponent<BoxCollider>();
        target = FindDeviceToChase();
        if (target == null) return;
        animatior.SetBool("IsMoving", true);
        navMeshAGent = this.GetComponent<NavMeshAgent>();
        SetDestination(target.transform);
    }

    void Update()
    {
        /*
        if (deviceWall.canGoUp == true)
        {
            animatior.SetBool("IsMoving", false);
        }
        */
        try
        {
            if (target.gameObject.CompareTag("DeviceInPlace")) return;
            ChaseNewTarget();
        }
        catch (NullReferenceException ex)
        {
            enemy.enabled = false;
            //animatior.SetBool("IsMoving", false);
            animatior.SetBool("IsDestroy", true);
            boxCollider.enabled = false;
            timer.StartTimedAction(DestroyCrab, 2f);
        }
       
    }

    private void ChaseNewTarget()
    {
        target = FindDeviceToChase();
        if (target != null)
        {
            SetDestination(target.transform);
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (target.GetComponent<DeviceWall>().startedRasingWall)
            {
                deviceWall = target.GetComponent<DeviceWall>();

                // if (collision.gameObject.CompareTag("DeviceInPlace"))
                // {
                deviceWall.device.transform.position = deviceWall.startingPosition;
                deviceWall.canGoUp = false;
                deviceWall.startedRasingWall = false;
                deviceWall.start = false;
            }
            /*
            //target.GetComponent<DeviceWall>().device.transform.position = target.GetComponent<DeviceWall>().startingPosition;
            enemy.enabled = false;
            //SetDestination(gameObject.transform);
            animatior.SetBool("IsDestroy", true);
            boxCollider.enabled = false;
            timer.StartTimedAction(DestroyCrab, 2f);
            */
            DisableEnemy();
            
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeviceInPlace") && other.gameObject == target)
        {
            animatior.SetBool("IsStanding", true);
            navMeshAGent.SetDestination(gameObject.transform.position);
            
            //gameObject.GetComponent<NavMeshAgent>().enabled = false;
            //gameObject.AddComponent<TimedAction>().StartTimedAction(DisableDevice, timeTillDestroy);         
        }
    }

    private void DisableDevice()
    {    
        enemy.enabled = false;
        //target.gameObject.tag = "Finish";
        //animatior.SetBool("IsMoving", false);
        animatior.SetBool("IsDestroy", true);
        boxCollider.enabled = false;
        timer.StartTimedAction(DestroyCrab, 2f);
    }

    public GameObject FindDeviceToChase()
    {
        GameObject[] placedDevices = GameObject.FindGameObjectsWithTag("DeviceInPlace");

        if (placedDevices.Length != 0)
        {
            int brojac = UnityEngine.Random.Range(0, placedDevices.Length);
            GameObject randomDevice = placedDevices[brojac];
            return randomDevice;
        }
        else return null;
    }
    public void DestroyCrab()
    {
        Destroy(gameObject);
    }
   public void DisableEnemy()
    {
        
        //animatior.SetBool("IsMoving", false);
        //animatior.SetBool("IsStanding", true);
        SetDestination(gameObject.transform);
        animatior.SetBool("IsDestroy", true);
        boxCollider.enabled = false;
        timer.StartTimedAction(DestroyCrab, 2.9f);
        enemy.enabled = false;
    }
}