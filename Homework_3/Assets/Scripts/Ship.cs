using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private MeshRenderer[] meshRenderers;

    public Color CurrentColor { get; private set; }

    private void Start()
    {
        this.meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    public void ChangeColor(Color color)
    {
        this.CurrentColor = color;

        foreach (var render in this.meshRenderers)
        {
            render.material.color = color;
        }
    }
}
