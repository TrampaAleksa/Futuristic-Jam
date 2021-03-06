﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour {
    Teleport[] teleports;
    public AudioSource pickUpPower;
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 1f;
    public float bonusMoveSpeed = 1f;
    public int bonusTime = 5;
    [SerializeField]
    float speedOfRotation = 5;
    [HideInInspector]
    public Rigidbody rb;
    Timer timer;
    void Start()
    {
        teleports = GameObject.FindObjectsOfType<Teleport>();
        rb = GetComponent<Rigidbody>();
        timer = GetComponentInChildren<Timer>();
    }
    private void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") != 0)
            rb.MovePosition(transform.position + transform.forward * (Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime));
       
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0, rotationSpeed * 20f * Input.GetAxis("Horizontal") * Time.fixedDeltaTime, 0);
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
            Debug.Log("power up: " + other.tag);
        }
        else
        if (other.gameObject.CompareTag("ms-"))
        {
            moveSpeed -= bonusMoveSpeed;
            SetSpeed();
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
            Debug.Log("power up: " + other.tag);

        }
        else
        if (other.gameObject.CompareTag("timer+"))
        {
            if (Timer.currentTime + bonusTime > timer.startingTime)
            {
                Timer.currentTime = timer.startingTime;
            }
            else Timer.currentTime += bonusTime;
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
            Debug.Log("power up: " + other.tag);

        }
        else
        if (other.gameObject.CompareTag("timer-"))
        {
            Timer.currentTime -= bonusTime;
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
            Debug.Log("power up: " + other.tag);

        }
        else
        if (other.gameObject.CompareTag("teleport+"))
        {
            TeleportsChanger(true);
            PowerController.Instance.SetTeleport(true);
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
            Debug.Log("power up: " + other.tag);
            SpawnPickUps.Instance.tags.RemoveAll((tag) =>tag == "teleport+");

        }else
        if(other.gameObject.CompareTag("teleport-"))
        {
            TeleportsChanger(false);
            PowerController.Instance.SetTeleport(false);
            SpawnPickUps.DestroyFromPlayer(help.gameObject);
            pickUpPower.Play();
            Debug.Log("power up: " + other.tag);

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
