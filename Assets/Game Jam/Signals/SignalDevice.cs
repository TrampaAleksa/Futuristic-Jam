using System;
using UnityEngine;

public class SignalDevice : MonoBehaviour
{
    public SignalDeviceInfo info;

    private void Awake()
    {
        info = GetComponent<SignalDeviceInfo>();
        info.InitSignals();
    }

}