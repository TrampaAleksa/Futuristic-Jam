using System;
using UnityEngine;
using UnityEngine.Events;

public class SignalBroadcaster : MonoBehaviour
{
    public RaycastHit hit;
    public UnityEvent<Signal> hitEvents;
    public UnityEvent<Signal> wallEvents;

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
        foreach (var signal in broadcaster.signals)
        {
            if (SignalInterrupted(signal))
                wallEvents?.Invoke(signal);
            else
                hitEvents?.Invoke(signal);
        }
    }
    
    private bool SignalInterrupted(Signal signal)
    {
        var receiverPosition = signal.receiver.transform.position;
        var broadcasterPosition = signal.broadcaster.transform.position;
        
        return Physics.Linecast(broadcasterPosition, receiverPosition, out signal.hit, LayerMask.GetMask("Wall"));
    }
}