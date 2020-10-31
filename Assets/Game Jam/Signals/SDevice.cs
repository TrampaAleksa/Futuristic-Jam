using System;
using System.Collections.Generic;
using UnityEngine;

public class SDevice : MonoBehaviour
{
    public int connections;

    [SerializeField] private List<SDevice> sendingTo;
    [NonSerialized] public List<SSignal> signals;
    [NonSerialized] public DeviceState state;

    private void Awake()
    {
        signals = new List<SSignal>();

        foreach (var sDevice in sendingTo)
        {
            var signal = new SSignal();
        }
        
        state = new DeviceSilent(this);
    }

    private void Update()
    {
        state.UpdateAction();
    }

    public bool HasConnections() => connections > 0;
}