using UnityEngine;

public class SignalDampener : MonoBehaviour
{
    public void DampenSignal(Signal signal)
    {
        var percentage = signal.Damperer;
        signal.line.startWidth = percentage / 10f;
        signal.line.endWidth = percentage / 10f;
    }
}