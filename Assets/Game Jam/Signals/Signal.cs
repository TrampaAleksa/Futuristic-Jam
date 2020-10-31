
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

    private float proximity;

    public SignalProximity Distance
    {
        get
        {
            var deviceDistance = Vector3.Distance(receiver.transform.position, broadcaster.transform.position);
            
            if (deviceDistance < (range/2f) )
            {
                Debug.Log("Signal: near");
                return SignalProximity.Near;
            }
            if (deviceDistance > (range/2f) && deviceDistance < range)
            {
                Debug.Log("Signal: far");
                return SignalProximity.Far;
            }
            else
            {
                Debug.Log("Signal: Out of range");
                return SignalProximity.OutOfRange;
            }
        }
    }
}

public enum SignalType
{
    Bad,
    Good
}

public enum SignalProximity
{
    Near,
    Far,
    OutOfRange
}