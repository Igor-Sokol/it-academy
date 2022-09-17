using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private float _sideForce;
    private float _forwardForce;
    private Rigidbody _body;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        this._body = GetComponent<Rigidbody>();
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
        _sideForce = Input.GetAxis("Horizontal") * this.rotationSpeed;
        _forwardForce = Input.GetAxis("Vertical") * this.movementSpeed;
    }

    private void Move()
    {
        if (this._sideForce != 0f)
        {
            this._body.angularVelocity = new Vector3(0.0f, _sideForce, 0.0f);
        }

        if (this._forwardForce != 0f)
        {
            this._body.velocity = this._body.transform.forward * _forwardForce;
        }
    }
}
