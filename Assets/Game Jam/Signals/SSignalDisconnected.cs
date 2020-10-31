public class SSignalDisconnected : SSignalState
{
    public SSignalDisconnected(SSignal signal) : base(signal)
    {
    }

    public override void Entry()
    {
        base.Entry();
        signal.Disconnect();
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        if (IsConnected)
        {
            Exit();
        }

        if (!signal.InRange)
        {
            signal.line.endWidth = 0;
            signal.line.startWidth = 0;
        }
        
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
        signal.state = new SSignalConnected(signal);
        signal.state.Entry();
    }
}