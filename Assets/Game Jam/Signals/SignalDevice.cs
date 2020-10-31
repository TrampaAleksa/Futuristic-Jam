using System;
using System.Collections.Generic;
using UnityEngine;

public class SignalDevice : MonoBehaviour
{
    public List<Signal> signals;

    private void Awake()
    {
        InitSignals(this);
        FindObjectOfType<SignalLineHolder>().InitLines(this);
    }
    
    private void InitSignals(SignalDevice broadcaster)
    {
        foreach (var signal in signals)
        {
            signal.broadcaster = broadcaster;
        }
    }

}