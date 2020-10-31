using UnityEngine;

public class SSignal
{
    public SDevice sender;
    public SDevice receiver;
    public LineRenderer line;
    public SignalType type;

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
}