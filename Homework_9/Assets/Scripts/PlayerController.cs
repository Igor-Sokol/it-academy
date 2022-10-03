using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _xVelocity;
    
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _xVelocity = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.Space) && _rigidbody.velocity.y == 0)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (_xVelocity != 0)
        {
            _rigidbody.velocity = new Vector2(_xVelocity, _rigidbody.velocity.y);
        }
    }
}
