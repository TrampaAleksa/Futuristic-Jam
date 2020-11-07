using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameObject teleport;
    Teleport teleport0, teleport1;
    //public void EnebleTeleport(int index)
    //{
    //    teleport = GameObject.FindGameObjectWithTag("teleport" + index);
    //    teleport.gameObject.GetComponent<Teleport>().enabled = true;
    //}
    //public void DisableTeleport(int index)
    //{
    //    teleport = GameObject.FindGameObjectWithTag("teleport" + index);
    //    teleport.gameObject.GetComponent<Teleport>().enabled = false;
    //}

    private void Update()
    {
     if(Player.teleport == 0)
        {
            teleport0.enabled = false;
            teleport1.enabled = false;
        }
        else
        {
            teleport0.enabled = true;
            teleport1.enabled = true;
        }
    }
}
