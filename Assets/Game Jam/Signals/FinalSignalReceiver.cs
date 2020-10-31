using UnityEngine;

public class FinalSignalReceiver : SignalReceiver
{
    public override void ReceiveSignal(Signal signal)
    {
        Debug.Log("Finished the Game");
    }
}