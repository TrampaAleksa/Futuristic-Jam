using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour {
    Teleport[] teleports;
    public AudioSource pickUpPower;
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 1f;
    [NonSerialized]
    public CharacterController player;
    public float bonusMoveSpeed = 1f;
    public int bonusTime = 5;

    public float initY;

    private Rigidbody rb;
    void Start() {
        teleports= GameObject.FindObjectsOfType<Teleport>();
        player = gameObject.GetComponent<CharacterController>();
        initY = transform.position.y;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 movementZ = Vector3.forward * (Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        Vector3 movement = transform.TransformDirection(movementZ);
        player.Move(movement);
        
        player.enabled = false;
        transform.position = new Vector3(transform.position.x, initY, transform.position.z);
        player.enabled = true;
        
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0, rotationSpeed * Input.GetAxis("Horizontal"), 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        GameObject help = other.gameObject;
      
        if (other.gameObject.CompareTag("ms+"))
        {
            moveSpeed += bonusMoveSpeed;
            SetSpeed();
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
        }
        else
        if (other.gameObject.CompareTag("ms-"))
        {
            moveSpeed -= bonusMoveSpeed;
            SetSpeed();
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
        }
        else
        if (other.gameObject.CompareTag("timer+"))
        {
            Timer.currentTime += bonusTime;
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
        }
        else
        if (other.gameObject.CompareTag("timer-"))
        {
            Timer.currentTime -= bonusTime;
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
        }
        else
        if (other.gameObject.CompareTag("teleport+"))
        {
            TeleportsChanger(true);
            PowerController.Instance.SetTeleport(true);
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
        }else
        if(other.gameObject.CompareTag("teleport-"))
        {
            TeleportsChanger(false);
            PowerController.Instance.SetTeleport(false);
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
        }
    }
    public void SetSpeed()
    {
        PowerController.Instance.SetSpeed(moveSpeed);
    }
    private void TeleportsChanger(bool isActive)
    {
        foreach (var item in teleports)
        {
           item.canTeleport=isActive;
        }
    }
}
