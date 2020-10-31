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
        isActive = signal.sender.HasConnections();
        if (isActive)
        {
            Exit();
        }
    }

    public override void Exit()
    {
        base.Exit();
        signal.state = new SSignalConnected(signal);
        signal.state.Entry();
    }
}