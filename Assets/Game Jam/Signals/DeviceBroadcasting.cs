using UnityEngine;

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
        foreach (var signal in device.signals)
        {
            signal.Connect();
        }
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        if (device.HasConnections())
        {
            UpdateSignal();
            return;
        }
        Exit();

    }

    private void UpdateSignal()
    {
    }

    public override void Exit()
    {
        base.Exit();
        SilentMode();
    }

    private void SilentMode()
    {
        device.state = new DeviceSilent(device);
    }
}