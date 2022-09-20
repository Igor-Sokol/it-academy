using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private float _yVelocity;
    
    [SerializeField] private float gravity;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float verticalRotationLimit;
    [SerializeField] private GameObject cameraContainer;
    [SerializeField] private Joystick joystick;
    [SerializeField] private TouchAxis touchAxis;

    public void Jump()
    {
        if (_characterController.isGrounded)
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
        Move();
        Gravity();
        Rotate();
    }

    private void Gravity()
    {
        if (_characterController.isGrounded)
        {
            _yVelocity = gravity;
        }
        else
        {
            _yVelocity += gravity * Time.deltaTime;
        }
        
        _characterController.Move(Vector3.up * (_yVelocity * Time.deltaTime));
    }
    
    private void Move()
    {
        if (_characterController.isGrounded)
        {
            float vertical = joystick.Axis.y * joystick.SpeedMultiplier;
            float horizontal = joystick.Axis.x * joystick.SpeedMultiplier;
        
            Vector3 movement = new Vector3(horizontal * speed, 0, vertical * speed);
            _characterController.Move(transform.TransformDirection(movement) * Time.deltaTime);   
        }
    }

    private void Rotate()
    {
        float horizontalRotation = touchAxis.Axis.x;
        _characterController.transform.Rotate(Vector3.up, horizontalRotation * rotationSpeed);

        float verticalRotation = touchAxis.Axis.y;
        
        float xCameraRotation = cameraContainer.transform.rotation.eulerAngles.x;
        xCameraRotation = xCameraRotation > 180 ? (xCameraRotation - 360f) : xCameraRotation;

        if (xCameraRotation <= verticalRotationLimit && verticalRotation < 0
            || xCameraRotation >= -verticalRotationLimit && verticalRotation > 0)
        {
            cameraContainer.transform.Rotate(Vector3.right, -verticalRotation * rotationSpeed);
        }
    }
}
