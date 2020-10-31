public class SSignalInactive : SSignalState
{
    public SSignalInactive(SSignal signal) : base(signal)
    {
    }

    public override void Entry()
    {
        base.Entry();
        signal.line.endWidth = 0;
        signal.line.startWidth = 0;
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
        signal.state = new SSignalActive(signal);
        signal.state.Entry();
        
        signal.line.endWidth = 0.04f;
        signal.line.startWidth = 0.04f;
    }
}