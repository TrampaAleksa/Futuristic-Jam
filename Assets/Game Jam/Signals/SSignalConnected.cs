﻿public class SSignalConnected : SSignalState
{
    public SSignalConnected(SSignal signal) : base(signal)
    {
    }

    public override void Entry()
    {
        base.Entry();
        signal.Connect();
    }

    public override void UpdateAction()
    {
        base.UpdateAction();

        if (!IsConnected)
        {
            Exit();
            return;
        }

        var width = signal.Damperer / 10f;
        signal.line.endWidth = width;
        signal.line.startWidth = width;

        if (signal.Interrupted())
        {
            SignalLineDrawer.WallLineDraw(signal);
            return;
        }
        
        SignalLineDrawer.ReceiverLineDraw(signal);

    }

    public override void Exit()
    {
        base.Exit();
        signal.state = new SSignalDisconnected(signal);
        signal.state.Entry();
    }
}