using UnityEngine;

public class SignalLineHolder : MonoBehaviour
{
    public LineRenderer redLine;
    public LineRenderer greenLine;

    public void InitLines(SignalDevice device)
    {
            if (device.signal.type == SignalType.Bad)
            {
                device.signal.line = Instantiate(redLine, transform);
            }
            else
            {
                device.signal.line = Instantiate(greenLine, transform);
            }
    }
}