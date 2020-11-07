using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PowerUp2 : MonoBehaviour
{
    //public GameObject pickupEffect;

 void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }
     void Pickup(Collider player)
        {
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        }
}
