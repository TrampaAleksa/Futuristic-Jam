using System;
using UnityEngine;
using UnityEngine.Events;

public class SignalSender : MonoBehaviour
{
    public RaycastHit hit;
    public UnityEvent<Signal> hitEvents;
    public UnityEvent<Signal> wallEvents;
    public UnityEvent<Signal> noRangeEvents;

    private SignalDevice broadcaster;

    public bool source;

    private void Awake()
    {
        broadcaster = GetComponent<SignalDevice>();

        if (broadcaster.signal.receiver != null)
        {
            hitEvents.AddListener( broadcaster.signal.receiver.GetComponent<SignalLineDrawer>().ReceiverLineDraw);
            hitEvents.AddListener( broadcaster.signal.receiver.GetComponent<SignalReceiver>().ReceiveSignal);
            hitEvents.AddListener( GetComponent<SignalDampener>().DampenSignal);

            wallEvents.AddListener(GetComponent<SignalLineDrawer>().WallLineDraw);
            wallEvents.AddListener(GetComponent<SignalDampener>().DampenSignal);
        
            noRangeEvents.AddListener(GetComponent<SignalDampener>().NoSignal);
        }
    }

    private void Update()
    {
        if (source)
        {
            SendBroadcast(broadcaster.signal);
        }
    }
    
    public virtual void SendBroadcast(Signal signal)
    {
            if (!signal.InRange)
            {
                noRangeEvents?.Invoke(signal);
                return;
            }
            
            if (SignalInterrupted(signal))
                wallEvents?.Invoke(signal);
            else
                hitEvents?.Invoke(signal);
    }
    
    private bool SignalInterrupted(Signal signal)
    {
        var receiverPosition = signal.receiver.transform.position;
        var broadcasterPosition = signal.broadcaster.transform.position;
        
        return Physics.Linecast(broadcasterPosition, receiverPosition, out signal.hit, LayerMask.GetMask("Wall"));
    }
}