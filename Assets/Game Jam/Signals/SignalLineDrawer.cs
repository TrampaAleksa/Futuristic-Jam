using UnityEngine;

public class SignalLineDrawer : MonoBehaviour
{  
    public void WallLineDraw(SignalDevice broadcaster, SignalDevice receiver)
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