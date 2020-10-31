using UnityEngine;

public class SignalBreaker : MonoBehaviour
{
    public virtual  void NoSignalRange(Signal signal)
    {
        StopDrawingLine(signal);
        signal.receiver.breakerSignal.NoSignalRange(signal.receiver.signal);
    }


    public void NoSignalWall(Signal signal)
    {
        signal.receiver.breakerSignal.NoSignalRange(signal.receiver.signal);
    }

    private static void StopDrawingLine(Signal signal)
    {
        signal.line.startWidth = 0;
        signal.line.endWidth = 0;
    }
}