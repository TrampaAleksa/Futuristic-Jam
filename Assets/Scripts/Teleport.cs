using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform endingPosition;
    public Vector3 spawnOffset;
    
    private AudioSource teleportSound;
    [SerializeField]private Player player;

    private void Awake()
    {
        teleportSound = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player"))
        {
            player.player.enabled = false;
            player.transform.position = endingPosition.transform.position + spawnOffset;
            var playerEnabled = player.player.enabled = true;
            teleportSound.Play();
        }
    }
    
}
