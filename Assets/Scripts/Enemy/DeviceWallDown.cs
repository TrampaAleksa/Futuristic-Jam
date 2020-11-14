using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceWallDown : MonoBehaviour
{
    [SerializeField]
    GameObject device;
    Vector3 startingPosition;
    [SerializeField]
    float speedOfRasingWall = 0.025f;
    [SerializeField]
    float timesSlowerMovingWall = 5;
    bool startedRasingWall = false;
    [SerializeField]
    float positionForActiveSignal = -0.9f;



    void Start()
    {
        startingPosition = device.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if(device.transform.localPosition.y >= -2.63 && other.gameObject.tag == "Player")
        {
            device.transform.Translate(Vector3.down * speedOfRasingWall / timesSlowerMovingWall * Time.deltaTime);
            if (device.transform.localPosition.y < positionForActiveSignal)
                gameObject.tag = "DeviceInPlace";
        }      
    }
}
