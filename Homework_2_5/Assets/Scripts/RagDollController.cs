using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollController : MonoBehaviour
{
    [SerializeField] private Rigidbody[] elements;

    private void Start()
    {
        Disable();
    }

    public void Enable()
    {
        foreach (var item in elements)
        {
            item.isKinematic = false;
        }
    }

    public void Disable()
    {
        foreach (var item in elements)
        {
            item.isKinematic = true;
        }
    }
}
