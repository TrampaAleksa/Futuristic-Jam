using UnityEngine;

public class SignalDevice : MonoBehaviour
{
    private SignalDeviceInfo info;
    private SignalDeviceBroadcaster broadcaster;
    private SignalReceiver receiver;

    private void Awake()
    {
        info = GetComponent<SignalDeviceInfo>();
        broadcaster = GetComponent<SignalDeviceBroadcaster>();
        receiver = GetComponent<SignalReceiver>();
    }
}