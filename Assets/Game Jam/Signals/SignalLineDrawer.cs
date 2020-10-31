using UnityEngine;

public class SignalLineDrawer : MonoBehaviour
{  
    public static void WallLineDraw(Signal signal)
    {
        var broadcasterPosition = signal.broadcaster.transform.position;
        var hitPoint = signal.hit.point;
        
        signal.line.SetPosition(0, broadcasterPosition);
        signal.line.SetPosition(1, hitPoint);
    }

    public static void ReceiverLineDraw(Signal signal)
    {
        var receiverPosition = signal.receiver.transform.position;
        var broadcasterPosition = signal.broadcaster.transform.position;
        
        signal.line.SetPosition(0, broadcasterPosition);
        signal.line.SetPosition(1, receiverPosition);
    }
    
    public static void ReceiverLineDraw(SSignal signal)
    {
        var receiverPosition = signal.receiver.transform.position;
        var broadcasterPosition = signal.sender.transform.position;
        
        signal.line.SetPosition(0, broadcasterPosition);
        signal.line.SetPosition(1, receiverPosition);
    }
    
}