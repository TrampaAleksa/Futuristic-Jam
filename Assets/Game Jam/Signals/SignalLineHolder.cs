using UnityEngine;

public class SignalLineHolder : MonoBehaviour
{
    public LineRenderer redLine;
    public LineRenderer greenLine;

    public void InitLines(SignalDevice device)
    {
        foreach (var signal in device.signals)
        {
            if (signal.type == SignalType.Bad)
            {
                signal.line = Instantiate(redLine, transform);
            }
            else
            {
                signal.line = Instantiate(greenLine, transform);
            }
        }
    }
}