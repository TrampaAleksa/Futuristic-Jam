using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalDeviceInfo : MonoBehaviour
{
    public LineRenderer line;
    public List<Signal> signals;
    
    public void InitSignals()
    {
        var broadcaster = GetComponent<SignalDevice>();
        foreach (var signal in signals)
        {
            signal.broadcaster = broadcaster;
        }
    }
}
