
using System;
using UnityEngine;

[Serializable]
public class Signal
{
    public SignalDevice receiver;
    public SignalType type;
    [SerializeField] private float range;

    [NonSerialized] public SignalDevice broadcaster;
    [NonSerialized] public RaycastHit hit;
    [NonSerialized] public LineRenderer line;

    [NonSerialized] public bool isActive;

    public float Damperer
    {
        get
        {
            var deviceDistance = Vector3.Distance(receiver.transform.position, broadcaster.transform.position);
            return Mathf.InverseLerp(range, 0, deviceDistance);
        }
    }

    public bool InRange { get => Vector3.Distance(receiver.transform.position, broadcaster.transform.position) < range * 0.9f;}

    public bool IsConnected
    {
        get
        {
            if (!InRange)
                return false;
            if (SignalInterrupted(this))
                return false;
            if (!isActive)
                return false;
            
            return true;
        }
    }
    
    private bool SignalInterrupted(Signal signal)
    {
        var receiverPosition = signal.receiver.transform.position;
        var broadcasterPosition = signal.broadcaster.transform.position;
        
        return Physics.Linecast(broadcasterPosition, receiverPosition, out signal.hit, LayerMask.GetMask("Wall"));
    }
}

public enum SignalType
{
    Bad,
    Good
}
