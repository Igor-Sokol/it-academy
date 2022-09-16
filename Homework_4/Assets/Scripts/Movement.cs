using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private float sideForce;
    private float forwardForce;
    private Rigidbody body;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        this.body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        this.ReadInput();
    }

    private void FixedUpdate()
    {
        this.Move();
    }

    private void ReadInput()
    {
        sideForce = Input.GetAxis("Horizontal") * this.rotationSpeed;
        forwardForce = Input.GetAxis("Vertical") * this.movementSpeed;
    }

    private void Move()
    {
        if (this.sideForce != 0f)
        {
            this.body.angularVelocity = new Vector3(0.0f, sideForce, 0.0f);
        }

        if (this.forwardForce != 0f)
        {
            this.body.velocity = this.body.transform.forward * forwardForce;
        }
    }
}
