using UnityEngine;

public class SSignal
{
    public SDevice sender;
    public SDevice receiver;
    public LineRenderer line;
    public SignalType type;
    public RaycastHit hit;

    public bool turnedOn;

    public SSignalState state;

    public void Disconnect()
    {
        receiver.connections--;
        if (receiver.connections < 0) receiver.connections = 0;
    }

    public void Connect()
    {
        receiver.connections++;
    }

    public bool Interrupted()
    {
        var receiverPosition = receiver.transform.position;
        var broadcasterPosition = sender.transform.position;

        return Physics.Linecast(broadcasterPosition, receiverPosition, out hit, LayerMask.GetMask("Wall"));
    }
}