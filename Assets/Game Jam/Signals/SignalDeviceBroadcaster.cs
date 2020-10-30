using System;
using UnityEngine;
using UnityEngine.Events;

public class SignalDeviceBroadcaster : MonoBehaviour
{
    public RaycastHit hit;
    public UnityEvent<SignalDevice, SignalDevice> hitEvents;
    public UnityEvent<SignalDevice, SignalDevice> wallEvents;

    private SignalDevice broadcaster;

    private void Awake()
    {
        broadcaster = GetComponent<SignalDevice>();
    }

    private void Update()
    {
        SendBroadcast();
    }
    
    protected virtual void SendBroadcast()
    {
        foreach (var signal in broadcaster.info.signals)
        {
            if (SignalInterrupted(broadcaster, signal.receiver))
                wallEvents?.Invoke(broadcaster, signal.receiver);
            else
                hitEvents?.Invoke(broadcaster, signal.receiver);
        }
    }
    
    private bool SignalInterrupted(SignalDevice broadcaster, SignalDevice receiver)
    {
        var receiverPosition = receiver.transform.position;
        var broadcasterPosition = broadcaster.transform.position;
        
        return Physics.Linecast(broadcasterPosition, receiverPosition, out hit, LayerMask.GetMask("Wall"));
    }
}