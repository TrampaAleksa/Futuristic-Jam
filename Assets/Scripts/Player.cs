using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour {

    public AudioSource pickUpPower;
    public float moveSpeed = 3.0f;
    [SerializeField]
    CharacterController player;
    public Text time;
    string currentTime;
    public float bonusMoveSpeed = 1f;
    public int bonusTime = 5;
    public static int teleport;
    void Start() {
        player = gameObject.GetComponent<CharacterController>();
        currentTime = time.text;
        teleport = 1;
    }


    void Update()
    {
        Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;
        Vector3 movement = transform.TransformDirection(movementZ);
        player.Move(movement);
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0, 3 * Input.GetAxis("Horizontal"), 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        int timer;

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
            int.TryParse(time.text, out timer);
            timer += bonusTime;
            Timer.currentTime = timer;
            //time.text = timer.ToString("0");
            Debug.Log("New time " + timer);
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
        }
        else
        if (other.gameObject.CompareTag("timer-"))
        {
            int.TryParse(time.text, out timer);
            timer -= bonusTime;
            Timer.currentTime = timer;
            Debug.Log("New time " + timer);
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
