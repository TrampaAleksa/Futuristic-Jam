using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceWall : MonoBehaviour
{
    [SerializeField]
    GameObject device;
    Vector3 startingPosition;
    [SerializeField]
    float speedOfRasingWall = 0.025f;
    bool startedRasingWall = false;
    void Start()
    {
        startingPosition = device.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (device.transform.localPosition.y < 0f)
        {
             if (other.gameObject.tag == "Enemy")
            {
                device.transform.Translate(Vector3.up * speedOfRasingWall);
                startedRasingWall = true;
            }
            else if(startedRasingWall)
            {
                device.transform.position = startingPosition;
                startedRasingWall = false;
            }
        }
        else startedRasingWall = false;

    }



}