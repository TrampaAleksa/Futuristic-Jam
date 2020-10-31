using UnityEngine;

public class DeviceState
{
    protected SDevice device;

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