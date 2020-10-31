﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class SDevice : MonoBehaviour
{
    public int connections;

    [SerializeField] private List<SignalConnection> sendingTo;
    [NonSerialized] public List<SSignal> signals;
    [NonSerialized] public DeviceState state;

    public SFinalDevice FinalDevice;

    private void Awake()
    {
        if (CompareTag("FinalDevice"))
        {
            FinalDevice = GetComponent<SFinalDevice>();
        }
        
        signals = new List<SSignal>();

        foreach (var connection in sendingTo)
        {
            var signal = new SSignal();
            
            signal.receiver = connection.device;
            signal.sender = this;
            signal.type = connection.type;
            signal.line = FindObjectOfType<SignalLineHolder>().InitLine(signal);
            signal.state = new SSignalDisconnected(signal);
            signal.range = connection.range;
            signals.Add(signal);
        }
        
        state = new DeviceSilent(this);
    }

    private void Update()
    {
        state.UpdateAction();
        
        foreach (var signal in signals)
        {
            signal.state.UpdateAction();
        }
    }

    public bool HasConnections() => connections > 0;
}

[Serializable]
public class SignalConnection
{
    [SerializeField] public SDevice device;
    [SerializeField] public SignalType type;
    [SerializeField] public float range;
}