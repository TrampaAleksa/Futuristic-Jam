public class SSignalActive : SSignalState
{
    public SSignalActive(SSignal signal) : base(signal)
    {
    }

    public override void UpdateAction()
    {
        base.UpdateAction();

        isActive = signal.sender.HasConnections();
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
        signal.state = new SSignalInactive(signal);
        signal.state.Entry();
    }
}