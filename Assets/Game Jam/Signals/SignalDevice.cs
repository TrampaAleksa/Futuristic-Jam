using System;
using System.Collections.Generic;
using UnityEngine;

public class SignalDevice : MonoBehaviour
{
    public Signal signal;
    [NonSerialized]public SignalReceiver receiver;
    [NonSerialized]public SignalSender sender;
    [NonSerialized] public SignalBreaker breakerSignal;

    private void Awake()
    {
        InitSignals(this);
        FindObjectOfType<SignalLineHolder>().InitLines(this);
        sender = GetComponent<SignalSender>();
        receiver = GetComponent<SignalReceiver>();
        breakerSignal = GetComponent<SignalBreaker>();
    }
    
    private void InitSignals(SignalDevice broadcaster)
    {
            signal.broadcaster = broadcaster;
    }

}