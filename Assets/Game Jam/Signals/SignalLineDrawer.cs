using UnityEngine;

public class SignalLineDrawer : MonoBehaviour
{  
    public void WallLineDraw(Signal signal)
    {
        var broadcasterPosition = signal.broadcaster.transform.position;
        var hitPoint = signal.hit.point;
        
        signal.broadcaster.line.SetPosition(0, broadcasterPosition);
        signal.broadcaster.line.SetPosition(1, hitPoint);
    }

    public void ReceiverLineDraw(Signal signal)
    {
        var receiverPosition = signal.receiver.transform.position;
        var broadcasterPosition = signal.broadcaster.transform.position;
        
        signal.broadcaster.line.SetPosition(0, broadcasterPosition);
        signal.broadcaster.line.SetPosition(1, receiverPosition);
    }
    
}