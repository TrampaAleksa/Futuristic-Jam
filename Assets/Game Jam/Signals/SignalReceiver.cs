using UnityEngine;

public class SignalReceiver : MonoBehaviour
{
    public virtual void ReceiveSignal(SignalDevice broadcaster, SignalDevice receiver = null)
    {
        print(gameObject.name + " received signal from " + broadcaster.name);
    }
}