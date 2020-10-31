using UnityEngine;

public class SignalReceiver : MonoBehaviour
{
    public virtual void ReceiveSignal(Signal signal)
    {
        print(signal.receiver + " received signal from " + signal.broadcaster.name);
        signal.receiver.sender.SendBroadcast(signal.receiver.signal);
    }
}