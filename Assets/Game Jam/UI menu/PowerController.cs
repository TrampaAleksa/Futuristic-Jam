using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerController : MonoBehaviour
{
    public static PowerController Instance;
    [SerializeField]
    private Text TeleportValue;
    [SerializeField]
    private Text TeleportOFF;
    [SerializeField]
    private Text TeleportON;

    [SerializeField]
    private Image SpeedImage;
    [SerializeField]
    private Text SpeedValue;
    private bool isPositive;



    private void Awake()
    {
        Instance = this;
        SetSpeed(1);
        SpeedValue.text = 1.ToString();
        SetTeleport(false);
    }
    public void SetTeleport(bool isOn)
    {
        if(isOn)
        {
            TeleportValue.text = TeleportON.text;
            TeleportValue.color = TeleportON.color;
        }
        else
        {
            TeleportValue.text = TeleportOFF.text;
            TeleportValue.color = TeleportOFF.color;
        }
    }
    public void SetSpeed(int speed)
    {
        if(speed>0)
        {
            if (!isPositive)
            {
                SpeedImage.rectTransform.Rotate(Vector3.forward * 180);
                isPositive = true;
            }
            SpeedValue.text = speed.ToString();
        }
        else if(speed<0)
        {
            if (isPositive)
            {
                SpeedImage.rectTransform.Rotate(Vector3.forward * 180);
                isPositive = false;
            }
            SpeedValue.text = (speed*-1).ToString();
        }
    }
}
