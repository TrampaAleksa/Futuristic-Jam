using System.Collections.Generic;
using UnityEngine;

public class SFinalDevice : MonoBehaviour
{
    public List<SSignal> receivedSignals = new List<SSignal>();

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

    public void RemoveSignal(SSignal signal)
    {
        bool win = true;
        receivedSignals.Remove(signal);
        
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