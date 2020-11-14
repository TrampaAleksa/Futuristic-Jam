using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalPulse : MonoBehaviour
{
    public LineRenderer line;
    public Vector2 pulseSpeed;
    private static readonly int BaseColorMap = Shader.PropertyToID("_BaseColorMap");
    public Vector2 offset;
    private void Update()
    {
        var material = line.material;
        offset -= pulseSpeed;

        material.SetTextureOffset(
            BaseColorMap,
            offset);
    }
}
