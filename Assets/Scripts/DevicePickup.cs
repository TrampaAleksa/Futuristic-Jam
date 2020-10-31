using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DevicePickup : MonoBehaviour
{
    private bool isPickedUp;
    [SerializeField]
    float sizeOfPickedUpDevice;

    [SerializeField]
    float vratiDeviceNaVisinu = 1; 

    private GameObject robot;
    // Start is called before the first frame update
    void Start()
    {
        isPickedUp = false;
        robot = GameObject.FindGameObjectWithTag("Player");        
    }
    // Update is called once per frame
    void Update()
    {       
        if(isPickedUp == true)
        {
            if (Input.GetAxis("Fire2") > 0)
            {
                this.gameObject.transform.parent = null;
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                this.gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                    vratiDeviceNaVisinu, transform.position.z);
                Vector3 newScale = transform.localScale;
                newScale.x = 1;
                newScale.y = 1;
                newScale.z = 1;
                transform.localScale = newScale;
                isPickedUp = false;
                this.gameObject.GetComponent<Collider>().enabled = true;                
            }
        }           
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("Click left mouse button to pick device up!");           
            if (Input.GetAxis("Fire1") > 0)
            {
                this.gameObject.transform.parent = robot.transform;
                this.gameObject.transform.position = GameObject.FindGameObjectWithTag("PickedUpDevice").transform.position;
                isPickedUp = true;
                
                // pokupljen device iznad glave               
                Vector3 newScale = gameObject.transform.localScale;
                newScale.x = sizeOfPickedUpDevice;
                newScale.y = sizeOfPickedUpDevice;
                newScale.z = sizeOfPickedUpDevice;
                transform.localScale = newScale;               
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                this.gameObject.GetComponent<Collider>().enabled = false;               
            }
        }
    }      
}
