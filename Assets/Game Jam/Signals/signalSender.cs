using System;
using UnityEngine;
using UnityEngine.Events;

public class SignalSender : MonoBehaviour
{
    public RaycastHit hit;
    private UnityEvent<Signal> signalReceivedEvents;
    private UnityEvent<Signal> wallEvents;
    private UnityEvent<Signal> noRangeEvents;

    private SignalDevice broadcaster;

    public bool source;

    private void Awake()
    {
        broadcaster = GetComponent<SignalDevice>();
        
        signalReceivedEvents = new UnityEvent<Signal>();
        wallEvents = new UnityEvent<Signal>();
        noRangeEvents = new UnityEvent<Signal>();

        if (broadcaster.signal.receiver != null)
        {
            signalReceivedEvents.AddListener( broadcaster.signal.receiver.GetComponent<SignalReceiver>().ReceiveSignal);
            
            signalReceivedEvents.AddListener( GetComponent<SignalLineDrawer>().ReceiverLineDraw);
            signalReceivedEvents.AddListener( GetComponent<SignalDampener>().DampenSignal);

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
                signalReceivedEvents?.Invoke(signal);
    }
    
    private bool SignalInterrupted(Signal signal)
    {
        var receiverPosition = signal.receiver.transform.position;
        var broadcasterPosition = signal.broadcaster.transform.position;
        
        return Physics.Linecast(broadcasterPosition, receiverPosition, out signal.hit, LayerMask.GetMask("Wall"));
    }
}
