using UnityEngine;
using UnityEngine.Events;

public class FinalSignalReceiver : SignalReceiver
{
    [SerializeField]private UnityEvent gameOver; 
    public override void ReceiveSignal(Signal signal)
    {
        Debug.Log("Finished the Game");
    }
}