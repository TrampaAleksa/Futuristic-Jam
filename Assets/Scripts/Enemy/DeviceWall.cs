using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceWall : MonoBehaviour
{
    //[SerializeField]
    public GameObject device;
    public Vector3 startingPosition;
    [SerializeField]
    float speedOfRasingWall = 0.025f;
    public bool startedRasingWall = false;
    //Enemy enemy;
    GameObject enemy;
    public bool start = false;
    public bool canGoUp = false;
    bool deviceAbove0 = false;
    bool playerFirst = false;
    public bool comingToThisOne = false;
    void Start()
    {
        startingPosition = device.transform.position;
    }
    private void Update()
    {
        if(canGoUp)
            device.transform.Translate(Vector3.up * speedOfRasingWall * Time.deltaTime);
        //if (device.transform.localPosition.y > 0f && deviceAbove0 == false)
        //  deviceAbove0 = true;
        if (startedRasingWall && start)
        {
            if (device.transform.localPosition.y > 0f)
            {
                startedRasingWall = false;
                enemy.GetComponent<BoxCollider>().enabled = false;
                gameObject.tag = "Finish";
                enemy.GetComponent<Enemy>().enabled = false;
                start = false;
                enemy.GetComponent<Enemy>().DisableEnemy();
                canGoUp = false;
                deviceAbove0 = false;
            }
            else if (playerFirst)
            {
                device.transform.position = startingPosition;
                startedRasingWall = false;
                canGoUp = false;
                start = false;
                comingToThisOne = false;
                try
                {
                    enemy.GetComponent<Enemy>().DisableEnemy();
                }
                catch { }
                playerFirst = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {       
       // if (device.transform.localPosition.y < 0f)
       // {
            if (other.gameObject.tag == "Enemy")
            {
                if (!start) {
                    enemy = other.gameObject;
                    if (gameObject == enemy.GetComponent<Enemy>().target)
                        start = true;
                }
                if (start)
                {
                    canGoUp = true;
                    startedRasingWall = true;
                }
            }
        if (startedRasingWall && other.gameObject.tag == "Player")
        {
            playerFirst = true;
        }
    }
      
}