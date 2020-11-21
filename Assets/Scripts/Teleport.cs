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
    Rigidbody rb;

    private void Awake()
    {

        teleportSound = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        PowerController.Instance.SetTeleport(canTeleport);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)  && canTeleport && isCollided)
        {
            player.transform.position = endingPosition.transform.position + spawnOffset;
            rb.MovePosition(player.gameObject.transform.position);
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
