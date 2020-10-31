using UnityEngine;

public class SSignal
{
    public SDevice sender;
    public SDevice receiver;
    public LineRenderer line;
    public SignalType type;
    public RaycastHit hit;
    public float range;

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
    
    public float Damperer
    {
        get
        {
            var deviceDistance = Vector3.Distance(receiver.transform.position, sender.transform.position);
            return Mathf.InverseLerp(range, 0, deviceDistance);
        }
    }
    
    public bool InRange
    {
        get => Vector3.Distance(receiver.transform.position, sender.transform.position) < range * 0.9f;
    }
}