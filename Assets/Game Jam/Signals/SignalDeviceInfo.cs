using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalDeviceInfo : MonoBehaviour
{
    public List<SignalDevice> signalReceivers;
    public float range;
}

public class SignalDeviceBroadcaster : MonoBehaviour
{
    public virtual void BroadcastSignal(SignalDevice receiver)
    {
        
    }
}

public class SignalReceiver : MonoBehaviour
{
    public virtual void ReceiveSignal(SignalDevice broadcaster)
    {
        
    }
}

public class SignalDevice : MonoBehaviour
{
    private SignalDeviceInfo info;
    private SignalDeviceBroadcaster broadcaster;
    private SignalReceiver receiver;

    private void Awake()
    {
        info = GetComponent<SignalDeviceInfo>();
        broadcaster = GetComponent<SignalDeviceBroadcaster>();
        receiver = GetComponent<SignalReceiver>();
    }
}
