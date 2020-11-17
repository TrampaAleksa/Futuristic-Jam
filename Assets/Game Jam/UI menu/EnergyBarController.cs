using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer energyBar;
    [SerializeField]
    private Color goodColor;
    [SerializeField]
    private Color badColor;
    private float divider=9.375f;

    public static EnergyBarController Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void SetTime(float time)
    {
        float offset = time / divider;
        energyBar.size=new Vector2(offset,0.78f);

        if(time<10)
        {
            energyBar.color = badColor;
        }
        else
        {
            energyBar.color = goodColor;
        }        
    }
}
