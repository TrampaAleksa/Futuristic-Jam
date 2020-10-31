using System;
using UnityEngine;

public class SignalLineHolder : MonoBehaviour
{
    public LineRenderer redLine;
    public LineRenderer greenLine;


    public static SignalLineHolder Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void InitLines(SignalDevice device)
    {
        if (device.signal.type == SignalType.Bad)
        {
            device.signal.line = Instantiate(redLine, transform);
        }
        else
        {
            device.signal.line = Instantiate(greenLine, transform);
        }
    }

    public void InitLine(SSignal signal)
    {
        if (signal.type == SignalType.Bad)
        {
            signal.line = Instantiate(redLine, transform);
        }
        else
        {
            signal.line = Instantiate(greenLine, transform);
        }
    }
}