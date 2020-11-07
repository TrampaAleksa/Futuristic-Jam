using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameObject teleport;
    public void EnebleTeleport(int index)
    {
        teleport = GameObject.FindGameObjectWithTag("teleport" + index);
        teleport.gameObject.GetComponent<Teleport>().enabled = true;
    }
    public void DisableTeleport(int index)
    {
        teleport = GameObject.FindGameObjectWithTag("teleport" + index);
        teleport.gameObject.GetComponent<Teleport>().enabled = false;
    }

    private void Update()
    {
        if (Player.teleports[0] == 0)
        {
            DisableTeleport(0);
        }
        else
        {
            EnebleTeleport(0);
        }
        if(Player.teleports[1] == 0)
        {
            DisableTeleport(0);
        }
        else
        {
            EnebleTeleport(0);
        }
    }
}
