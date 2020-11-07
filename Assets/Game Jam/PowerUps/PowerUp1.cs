using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PowerUp1 : MonoBehaviour
{
    //public GameObject pickupEffect;

 void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }
     void Pickup()
        {
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        }
}
