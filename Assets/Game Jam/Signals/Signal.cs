﻿
using System;
using UnityEngine;

[Serializable]
public class Signal
{
    public SignalDevice receiver;
    public SignalType type;
    [SerializeField]private float range;

    [NonSerialized] public SignalDevice broadcaster;
    private float distance;
    private float inRange;

    public float Distance => distance;
    public float InRange => inRange;
}

public enum SignalType
{
    Bad,
    Good
}