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
        foreach (var signal in device.signals)
        {
            signal.Disconnect();
        }
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        CheckForConnections();
    }

    private void CheckForConnections()
    {
        if (device.HasConnections())
        {
            Exit();
        }
    }

    public override void Exit()
    {
        base.Exit();
        BroadcastMode();
    }

    private void BroadcastMode()
    {
        device.state = new DeviceBroadcasting(device);
        device.state.Entry();
    }
}