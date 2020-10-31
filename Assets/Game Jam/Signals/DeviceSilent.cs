public class DeviceSilent : DeviceState
{
    public DeviceSilent(SDevice device) : base(device)
    {
    }

    public override void Entry()
    {
        base.Entry();
        StopSignals();
    }

    private void StopSignals()
    {
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        CheckForConnections();
    }

    private void CheckForConnections()
    {
    }

    public override void Exit()
    {
        base.Exit();
        StartBroadcasting();
    }

    private void StartBroadcasting()
    {
        
    }
}