using UnityEngine;

public class SignalReceiver : MonoBehaviour
{
    public virtual void ReceiveSignal(Signal signal)
    {
        signal.receiver.sender.SendBroadcast(signal.receiver.signal);
    }
}