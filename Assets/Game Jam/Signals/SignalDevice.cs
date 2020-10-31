using System;
using System.Collections.Generic;
using UnityEngine;

public class SignalDevice : MonoBehaviour
{
    public Signal signal;
    public SignalSender broadcaster;

    private void Awake()
    {
        InitSignals(this);
        FindObjectOfType<SignalLineHolder>().InitLines(this);
        broadcaster = GetComponent<SignalSender>();
    }
    
    private void InitSignals(SignalDevice broadcaster)
    {
            signal.broadcaster = broadcaster;
    }

}