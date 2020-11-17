using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceWall : MonoBehaviour
{
    public GameObject device;
    public Vector3 startingPosition;
    public float speedOfRasingWall = 0.025f;
    [HideInInspector]
    public bool startedRasingWall = false;
    GameObject enemy;
    [HideInInspector]
    public bool start = false;
    [HideInInspector]
    public bool canGoUp = false;
    bool playerFirst = false;
    [HideInInspector]
    public bool comingToThisOne = false;
    void Start()
    {
        startingPosition = device.transform.position;
    }
    private void Update()
    {
        if(canGoUp)
            device.transform.Translate(Vector3.up * speedOfRasingWall * Time.deltaTime);
        if (startedRasingWall && start)
        {
            if (device.transform.localPosition.y > 0f)
            {
                gameObject.tag = "Finish";
                DestroyingEnemy();
                enemy.GetComponent<Enemy>().DisableEnemy();
                
            }
            else if (playerFirst)
            {
                device.transform.position = startingPosition;
                DestroyingEnemy();
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
    public void DestroyingEnemy()
    {
        startedRasingWall = false;
        start = false;
        canGoUp = false;
    }
}