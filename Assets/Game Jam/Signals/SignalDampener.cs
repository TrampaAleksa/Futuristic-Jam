using UnityEngine;

public class SignalDampener : MonoBehaviour
{
    public void DampenSignal(Signal signal)
    {
        switch (signal.Distance)
        {
            case SignalProximity.Near:
                signal.line.startWidth = 0.4f;
                signal.line.endWidth = 0.4f;
                break;
            case SignalProximity.Far:
                signal.line.startWidth = 0.2f;
                signal.line.endWidth = 0.2f;
                break;
            case SignalProximity.OutOfRange:
                signal.line.startWidth = 0f;
                signal.line.endWidth = 0f;
                break;
        }
    }
}