public class Signal
{
    private SignalDevice receiver;
    private SignalDevice broadcaster;
    private SignalType type;
    private float range;
    
    private float distance;
    private float inRange;

    public Signal(SignalDevice receiver, SignalDevice broadcaster, float range, SignalType type)
    {
        this.receiver = receiver;
        this.broadcaster = broadcaster;
        this.range = range;
        this.type = type;
    }

    public float Distance => distance;
    public float InRange => inRange;
}

public enum SignalType
{
    Bad,
    Good
}