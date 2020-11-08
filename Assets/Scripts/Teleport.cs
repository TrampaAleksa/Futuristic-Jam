using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject endingPosition;
    public GameObject player;
    public Vector3 spawnOffset;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            other.gameObject.transform.position = endingPosition.transform.position + spawnOffset;
        }
    }
}
