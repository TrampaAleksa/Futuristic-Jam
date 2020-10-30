using UnityEngine;

public class SignalLineHolder : MonoBehaviour
{
    public LineRenderer redLine;
    public LineRenderer greenLine;

    public void InitLines(SignalDevice device)
    {
        device.line = Instantiate(greenLine, transform);
    }
}