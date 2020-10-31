using UnityEngine;

public class SSignal
{
    public SDevice sender;
    public SDevice receiver;
    public LineRenderer line;
    public SignalType type;

    public void Disconnect()
    {
        receiver.connections--;
    }
    
    public void Connect()
    {
        receiver.connections++;
    }
    
    
}