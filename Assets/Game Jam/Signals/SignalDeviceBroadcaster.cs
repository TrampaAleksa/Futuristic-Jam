using UnityEngine;

public class SignalDeviceBroadcaster : MonoBehaviour
{
    public virtual void SendBroadcast(SignalDevice broadcaster)
    {
        foreach (var broadcastReceiver in broadcaster.info.broadcastReceivers)
        {
            var receiverPosition = broadcastReceiver.transform.position;
            var broadcasterPosition = broadcaster.transform.position;
            
            if (Physics.Linecast(broadcasterPosition, receiverPosition, LayerMask.GetMask("Wall")))
            {
                Debug.Log("blocked");
            }
            
            broadcaster.info.line.SetPosition(0, broadcasterPosition);
            broadcaster.info.line.SetPosition(1, receiverPosition);
            
            broadcastReceiver.receiver.ReceiveSignal(broadcaster);
        }
        
    }
}