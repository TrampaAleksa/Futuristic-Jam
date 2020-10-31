public class SSignalState
{
    public bool isActive;
    public SSignal signal;

    public SSignalState(SSignal signal)
    {
        this.signal = signal;
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