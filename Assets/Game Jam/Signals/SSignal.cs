public class SSignal
{
    public SDevice sender;
    public SDevice receiver;

    public bool isActive;


    public void Disconnect()
    {
        receiver.connections--;
    }
    
    public void Connect()
    {
        receiver.connections++;
    }
}