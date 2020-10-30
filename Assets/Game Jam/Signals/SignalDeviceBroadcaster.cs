using UnityEngine;

public class SignalDeviceBroadcaster : MonoBehaviour
{
    public virtual void SendBroadcast(SignalDevice broadcaster)
    {
        foreach (var broadcastReceiver in broadcaster.info.broadcastReceivers)
        {
            broadcastReceiver.receiver.ReceiveSignal(broadcaster);
            print("SignalDevice: Broadcasting signal to " + broadcastReceiver.name);

        }
        

    }
}