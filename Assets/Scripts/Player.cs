using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour {

    public AudioSource pickUpPower;
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 1f;
    [NonSerialized]
    public CharacterController player;
    public float bonusMoveSpeed = 1f;
    public int bonusTime = 5;
    public static int teleport;

    public float initY;
    void Start() {
        player = gameObject.GetComponent<CharacterController>();
        teleport = 1;
        initY = transform.position.y;
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
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
        }
        else
        if (other.gameObject.CompareTag("ms-"))
        {
            moveSpeed -= bonusMoveSpeed;
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
        }
        else
        if (other.gameObject.CompareTag("timer+"))
        {
            Timer.currentTime += bonusTime;
            //time.text = timer.ToString("0");
            Debug.Log("New time " + Timer.currentTime);
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
        }
        else
        if (other.gameObject.CompareTag("timer-"))
        {
            Timer.currentTime -= bonusTime;
            Debug.Log("New time " + Timer.currentTime);
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
        }
        else
        if (other.gameObject.CompareTag("teleport+"))
        {
            teleport = 1;
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
        }else
        if(other.gameObject.CompareTag("teleport-"))
        {
            teleport = 1;
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
        }
        
    }
}
