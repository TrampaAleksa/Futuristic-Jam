using UnityEngine;

public class SignalReceiver : MonoBehaviour
{
    public virtual void ReceiveSignal(Signal signal)
    {
        print(gameObject.name + " received signal from " + signal.broadcaster.name);
    }
}