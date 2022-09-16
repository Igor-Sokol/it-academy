using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody body;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        this.body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        this.Move();
    }

    private void Move()
    {
        float sideForce = Input.GetAxis("Horizontal") * this.rotationSpeed;
        if (sideForce != 0f)
        {
            this.body.angularVelocity = new Vector3(0.0f, sideForce, 0.0f);
        }

        float forwardForce = Input.GetAxis("Vertical") * this.movementSpeed;
        if (forwardForce != 0f)
        {
            this.body.velocity = this.body.transform.forward * forwardForce;
        }
    }
}
