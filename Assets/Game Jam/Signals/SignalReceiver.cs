using UnityEngine;

public class SignalReceiver : MonoBehaviour
{
    public virtual void ReceiveSignal(SignalDevice broadcaster)
    {
        print("SignalDevice:" + gameObject.name + " Received signal from " + broadcaster.name);
    }
}