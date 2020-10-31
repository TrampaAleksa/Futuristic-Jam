public class DeviceBroadcasting : DeviceState
{
    public DeviceBroadcasting(SDevice device) : base(device)
    {
    }

    public override void Entry()
    {
        base.Entry();
        ConnectToDevices();
    }


    private void ConnectToDevices()
    {
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        CheckConnections();
        UpdateSignal();
    }

    private void CheckConnections()
    {
    }

    private void UpdateSignal()
    {
    }

    public override void Exit()
    {
        base.Exit();
        DisconnectFromDevices();
        SilentMode();
    }

    private void SilentMode()
    {
    }

    private void DisconnectFromDevices()
    {
    }
}