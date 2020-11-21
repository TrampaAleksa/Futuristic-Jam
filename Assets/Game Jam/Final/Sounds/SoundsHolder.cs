using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsHolder : MonoBehaviour
{
    public AudioSource speedUp;
    public AudioSource speedDown;
    public AudioSource timeDown;
    public AudioSource timeUp;
    public AudioSource teleportOn;
    public AudioSource teleportOff;

    public static SoundsHolder Instance;

    private void Awake()
    {
        Instance = this;
    }
}