using UnityEngine;
using UnityEngine.Events;

public class SignalDeviceBroadcaster : MonoBehaviour
{
    private RaycastHit hit;
    public UnityEvent<SignalDevice, SignalDevice> hitEvents;
    public UnityEvent<SignalDevice, SignalDevice> wallEvents;

    public virtual void SendBroadcast(SignalDevice broadcaster)
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

    public void WallLineDraw(SignalDevice broadcaster,SignalDevice receiver)
    {
        var broadcasterPosition = broadcaster.transform.position;
        var hitPoint = broadcaster.broadcaster.hit.point;
        
        broadcaster.info.line.SetPosition(0, broadcasterPosition);
        broadcaster.info.line.SetPosition(1, hitPoint);
    }

    public void ReceiverLineDraw(SignalDevice broadcaster, SignalDevice receiver)
    {
        var receiverPosition = receiver.transform.position;
        var broadcasterPosition = broadcaster.transform.position;
        
        broadcaster.info.line.SetPosition(0, broadcasterPosition);
        broadcaster.info.line.SetPosition(1, receiverPosition);
    }
    
}

