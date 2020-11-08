using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform endingPosition;
    public Vector3 spawnOffset;
    
    private AudioSource teleportSound;
    [SerializeField]private Player player;
    private bool isPlayerTrigger = false;

    private void Awake()
    {
        teleportSound = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerTrigger)
        {
            player.player.enabled = false;
            player.transform.position = endingPosition.transform.position + spawnOffset;
            var playerEnabled = player.player.enabled = true;
            teleportSound.Play();
            isPlayerTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerTrigger = false;
        }
    }
}
