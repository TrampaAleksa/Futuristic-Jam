using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceWallDown : MonoBehaviour
{
    [SerializeField]
    GameObject device;
    [SerializeField]
    float timesSlowerMovingWall = 2;
    [SerializeField]
    float positionForActiveSignal = -0.9f;
    float sppedOfGoingUp;
    public float startinWallgPositionY = -2.63f;
    DeviceWall deviceWall;
    bool startedGoingDown = false;

    void Start()
    {
        deviceWall = GetComponent<DeviceWall>();
        sppedOfGoingUp = GetComponent<DeviceWall>().speedOfRasingWall;
    }
    private void Update()
    {
        if (startedGoingDown)
        {
            device.transform.Translate(Vector3.down * sppedOfGoingUp / timesSlowerMovingWall * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (device.transform.localPosition.y >= startinWallgPositionY && other.gameObject.tag == "Player")
        {
            startedGoingDown = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        startedGoingDown = false;
        if (device.transform.localPosition.y < positionForActiveSignal && other.gameObject.tag == "Player")
        {
            gameObject.tag = "DeviceInPlace";
            deviceWall.comingToThisOne = false;
        }
    }
}
