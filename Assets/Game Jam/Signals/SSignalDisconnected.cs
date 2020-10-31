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
    }

    public override void Exit()
    {
        base.Exit();
        signal.state = new SSignalConnected(signal);
        signal.state.Entry();
    }
}