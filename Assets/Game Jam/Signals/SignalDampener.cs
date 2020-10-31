using UnityEngine;

public class SignalDampener : MonoBehaviour
{
    public void DampenSignal(Signal signal)
    {
        var percentage = signal.Damperer;

        signal.line.startWidth = percentage / 10f;
        signal.line.endWidth = percentage / 10f;
    }

    public void NoSignal(Signal signal)
    {
        signal.line.startWidth = 0;
        signal.line.endWidth = 0;
    }
}