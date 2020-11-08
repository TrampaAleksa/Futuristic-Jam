using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationSpeed : MonoBehaviour
{
    public float rotationSpeed;
    private void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0, rotationSpeed * Input.GetAxis("Horizontal"), 0);
        }
    }

}
