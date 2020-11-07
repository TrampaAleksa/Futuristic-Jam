﻿using UnityEngine;

public class SignalLineDrawer
{
    public static void ReceiverLineDraw(Signal signal)
    {
        var receiverPosition = signal.receiver.transform.position;
        var broadcasterPosition = signal.sender.transform.position;
        
        signal.line.SetPosition(0, broadcasterPosition);
        signal.line.SetPosition(1, receiverPosition);
    }
    
    public static void WallLineDraw(Signal signal)
    {
        var broadcasterPosition = signal.sender.transform.position;
        var hitPoint = signal.hit.point;
        
        signal.line.SetPosition(0, broadcasterPosition);
        signal.line.SetPosition(1, hitPoint);
    }
    
}