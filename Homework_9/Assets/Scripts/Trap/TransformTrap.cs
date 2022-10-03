using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTrap : Trap
{
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Vector3 _startScale;
    
    protected override void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
        _startScale = transform.localScale;
    }

    public override void Reload()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        transform.localScale = _startScale;
    }
}
