using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceWallDown : MonoBehaviour
{
    [SerializeField]
    GameObject device;
    [SerializeField]
    float timesSlowerMovingWall = 5;
    [SerializeField]
    float positionForActiveSignal = -0.9f;
    float sppedOfGoingUp;
    DeviceWall deviceWall;

    void Start()
    {
        deviceWall = GetComponent<DeviceWall>();
        sppedOfGoingUp = GetComponent<DeviceWall>().speedOfRasingWall;
    }

    private void OnTriggerStay(Collider other)
    {
        if(device.transform.localPosition.y >= -2.63 && other.gameObject.tag == "Player")
        {
            device.transform.Translate(Vector3.down * sppedOfGoingUp / timesSlowerMovingWall * Time.deltaTime);
            if (device.transform.localPosition.y < positionForActiveSignal)
            {
                gameObject.tag = "DeviceInPlace";
                deviceWall.comingToThisOne = false;
            }
        }
    }
    
}
