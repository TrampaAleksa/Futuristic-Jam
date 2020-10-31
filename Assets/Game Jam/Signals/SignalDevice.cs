using System;
using System.Collections.Generic;
using UnityEngine;

public class SignalDevice : MonoBehaviour
{
    public Signal signal;
    public SignalReceiver receiver;
    public SignalSender sender;

    private void Awake()
    {
        InitSignals(this);
        FindObjectOfType<SignalLineHolder>().InitLines(this);
        sender = GetComponent<SignalSender>();
        receiver = GetComponent<SignalReceiver>();
    }
    
    private void InitSignals(SignalDevice broadcaster)
    {
            signal.broadcaster = broadcaster;
    }

}