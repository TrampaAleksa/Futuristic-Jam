using System.Collections.Generic;
using UnityEngine;

public class SFinalDevice : SDevice
{
    public List<SSignal> receivedSignals;

    public void ReceiveSignal(SSignal signal)
    {
        receivedSignals.Add(signal);
        bool win = true;

        foreach (var signals in receivedSignals)
        {
            if (signal.type == SignalType.Bad)
            {
                win = false;
            }
        }

        if (win)
        {
            Debug.Log("Game Over");
        }
    }
}