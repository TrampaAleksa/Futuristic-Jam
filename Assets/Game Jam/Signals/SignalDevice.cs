using System;
using UnityEngine;

public class SignalDevice : MonoBehaviour
{
    public  SignalDeviceInfo info;
    [NonSerialized] public SignalDeviceBroadcaster broadcaster;
    [NonSerialized] public SignalReceiver receiver;

    private void Awake()
    {
        info = GetComponent<SignalDeviceInfo>();
        broadcaster = GetComponent<SignalDeviceBroadcaster>();
        receiver = GetComponent<SignalReceiver>();
    }

    private void Update()
    {
        broadcaster.SendBroadcast(this);
    }

}