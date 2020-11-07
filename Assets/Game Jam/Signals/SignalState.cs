public class SignalState
{
    public bool IsConnected { get => signal.turnedOn && !signal.Interrupted() && signal.InRange;}
    public Signal signal;

    public SignalState(Signal signal)
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