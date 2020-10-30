using UnityEngine;

public class SignalDeviceBroadcaster : MonoBehaviour
{
    public virtual void SendBroadcast(SignalDevice broadcaster)
    {
        foreach (var broadcastReceiver in broadcaster.info.broadcastReceivers)
        {
            broadcaster.info.line.SetPosition(0, broadcaster.transform.position);
            broadcaster.info.line.SetPosition(1, broadcastReceiver.transform.position);
            
            broadcastReceiver.receiver.ReceiveSignal(broadcaster);
        }
        
        

    }
}