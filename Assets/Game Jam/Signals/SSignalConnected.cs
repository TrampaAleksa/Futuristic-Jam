public class SSignalConnected : SSignalState
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

        isActive = signal.turnedOn;
        if (!isActive)
        {
            Exit();
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