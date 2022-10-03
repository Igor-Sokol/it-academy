using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JointTrap : TransformTrap
{
    private Rigidbody2D _rigidbody;

    protected override void Start()
    {
        base.Start();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void Reload()
    {
        base.Reload();
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = 0f;
    }
}
