﻿using UnityEngine;

public class SignalReceiver : MonoBehaviour
{
    public virtual void ReceiveSignal(Signal signal)
    {
        print(signal.receiver + " received signal from " + signal.broadcaster.name);
        signal.receiver.broadcaster.SendBroadcast(signal.receiver.signal);
    }
}

public class FinalSignalReceiver : SignalReceiver
{
    public override void ReceiveSignal(Signal signal)
    {
        base.ReceiveSignal(signal);
        Debug.Log("Finished the Game");
    }
}