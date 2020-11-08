using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Teleport teleport0, teleport1;

    private void Update()
    {
        if (Player.teleport == 0 && teleport0.enabled)
        {
            teleport0.enabled = false;
            teleport1.enabled = false;
        }
        else if (!teleport0.enabled)
        {
            teleport0.enabled = true;
            teleport1.enabled = true;
        }
    }
}