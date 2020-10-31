using UnityEngine;

public class DeviceState
{
    private SDevice device;

    public DeviceState(SDevice device)
    {
        this.device = device;
    }

    public virtual void Entry()
    {
        
    }

    public virtual void UpdateAction()
    {
        
    }

    public virtual void Exit()
    {
        
    }
}