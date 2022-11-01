using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private float _yVelocity;
    private float _stepTimer;

    [SerializeField] private float gravity;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed;

    private void Jump()
    {
        if (_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _yVelocity = jumpForce;
        }
    }
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        Jump();
        _characterController.Move((Movement() + Gravity()) * Time.deltaTime);
        
        Rotate();
    }

    private Vector3 Gravity()
    {
        if (_characterController.isGrounded && _yVelocity < 0)
        {
            _yVelocity = gravity;
        }
        else
        {
            _yVelocity += gravity * Time.deltaTime;
        }
        
        return Vector3.up * _yVelocity;
    }
    
    private Vector3 Movement()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        
        Vector3 movement = new Vector3(horizontal * speed, 0, vertical * speed);

        return transform.TransformDirection(movement);
    }

    private void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        _characterController.transform.Rotate(Vector3.up, horizontalRotation * rotationSpeed);
    }
}
