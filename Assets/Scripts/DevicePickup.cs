using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DevicePickup : MonoBehaviour
{
    private static bool isPickedUp;
    [SerializeField] float sizeOfPickedUpDevice;

    [SerializeField] float vratiDeviceNaVisinu = 1;

    private GameObject robot;

    private GameObject pickedUpDevice;

    public GameObject deviceHolder;

    private static string pickedUpDeviceName = " ";

    // Start is called before the first frame update
    void Start()
    {
        isPickedUp = false;
        robot = GameObject.FindGameObjectWithTag("Player");
        pickedUpDevice = GameObject.FindGameObjectWithTag("PickedUpDevice");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire2") > 0)
        {
            if (isPickedUp == true && pickedUpDeviceName == gameObject.name)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                this.gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                    vratiDeviceNaVisinu, transform.position.z);
                Vector3 newScale = transform.localScale;
                newScale.x = 1;
                newScale.y = 1;
                newScale.z = 1;
                transform.localScale = newScale;
                this.gameObject.transform.parent = deviceHolder.transform;
                isPickedUp = false;
                this.gameObject.GetComponent<Collider>().enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isPickedUp == true) return;
            print("Click left mouse button to pick device up!");
            if (Input.GetAxis("Fire1") > 0)
            {
                this.gameObject.transform.parent = robot.transform;
                this.gameObject.transform.position = pickedUpDevice.transform.position;
                isPickedUp = true;

                // pokupljen device iznad glave               
                Vector3 newScale = gameObject.transform.localScale;
                newScale.x = sizeOfPickedUpDevice;
                newScale.y = sizeOfPickedUpDevice;
                newScale.z = sizeOfPickedUpDevice;
                transform.localScale = newScale;
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                this.gameObject.GetComponent<Collider>().enabled = false;

                pickedUpDeviceName = gameObject.name;
            }
        }
    }
}