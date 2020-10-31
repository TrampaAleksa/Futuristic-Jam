
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

    public float Damperer
    {
        get
        {
            var deviceDistance = Vector3.Distance(receiver.transform.position, broadcaster.transform.position);
            return Mathf.InverseLerp(range, 0, deviceDistance);
        }
    }

    public bool InRange { get => Vector3.Distance(receiver.transform.position, broadcaster.transform.position) < range * 0.9f;}
}

public enum SignalType
{
    Bad,
    Good
}
