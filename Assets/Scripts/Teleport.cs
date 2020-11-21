using System;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public bool canTeleport=false;
    public Transform endingPosition;
    public Vector3 spawnOffset;
    private bool isCollided;
    
    private AudioSource teleportSound;
    [SerializeField]private Player player;

    private void Awake()
    {
        teleportSound = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Start()
    {
        PowerController.Instance.SetTeleport(canTeleport);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)  && canTeleport && isCollided)
        {
            player.player.enabled = false;
            player.transform.position = endingPosition.transform.position + spawnOffset;
            var playerEnabled = player.player.enabled = true;
            teleportSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            isCollided = true;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCollided = false;
        }
    }
}
