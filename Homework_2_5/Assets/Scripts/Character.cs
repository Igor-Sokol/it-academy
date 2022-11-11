using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class Character : MonoBehaviour
{
    private (int id, float value) _speedAnimatorParam;
    private (int id, float value) _speedYAnimatorParam;
    private (int id, float value) _attackTypesRangeAnimatorParam;
    private int _attackAnimatorParam;
    private int _jumpAnimatorParam;
    private int _landAnimatorParam;
    private int _dieAnimatorParam;
    
    private float _rotationAngel;
    private float _speedY;
    private bool _isJumping;
    private bool _spawned;
    private bool _isAlive = true;
    private bool _isAttacking;
    private CharacterController _characterController;
    private Animator _characterAnimator;
    private AnimatorStateInfo _spawnAnimation;

    [SerializeField] private float gravity;
    [SerializeField] private float jumpForce;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Camera characterCamera;
    [SerializeField] private float animationBlendSpeed;
    [SerializeField] private RagDollController ragDollController;

    public event UnityAction OnDied;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _characterAnimator = GetComponent<Animator>();
        
        _speedAnimatorParam.id = Animator.StringToHash("Speed");
        _speedYAnimatorParam.id = Animator.StringToHash("SpeedY");
        _attackTypesRangeAnimatorParam.id = Animator.StringToHash("AttackTypesRange");
        _jumpAnimatorParam = Animator.StringToHash("Jump");
        _landAnimatorParam = Animator.StringToHash("Land");
        _dieAnimatorParam = Animator.StringToHash("Die");
        _attackAnimatorParam = Animator.StringToHash("Attack");
        
        _characterAnimator.speed = 0;
    }

    private void Update()
    {
        if (!_spawned || !_isAlive) return;

        if (Input.GetKeyDown(KeyCode.D))
        {
            Die();
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        
        Movement();
    }

    private void Movement()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && !_isJumping && _characterController.isGrounded)
        {
            _isJumping = true;
            _characterAnimator.SetTrigger(_jumpAnimatorParam);
            _speedY = jumpForce;
        }

        if (!_characterController.isGrounded)
        {
            _speedY += gravity * Time.deltaTime;
        }
        else if (_speedY <= 0f)
        {
            _speedY = gravity;
        }
        _characterAnimator.SetFloat(_speedYAnimatorParam.id, _speedY / jumpForce);
        
        if (_isJumping && _speedY < 0f)
        {
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.4f, LayerMask.GetMask("Default")))
            {
                _isJumping = false;
                _characterAnimator.SetTrigger(_landAnimatorParam);
            }
        }

        bool isSprint = Input.GetKey(KeyCode.LeftShift);
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        Vector3 rotatedMovement = Quaternion.Euler(0f, characterCamera.transform.rotation.eulerAngles.y, 0f) * movement.normalized;
        Vector3 verticalMovement = Vector3.up * _speedY;
        float currentSpeed = isSprint ? sprintSpeed : movementSpeed;
        _characterController.Move((verticalMovement + rotatedMovement * currentSpeed) * Time.deltaTime);

        if (rotatedMovement.sqrMagnitude > 0f)
        {
            _rotationAngel = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
            _speedAnimatorParam.value = isSprint ? 1f : 0.5f;
        }
        else
        {
            _speedAnimatorParam.value = 0f;
        }
        _characterAnimator.SetFloat(_speedAnimatorParam.id, Mathf.Lerp(
            _characterAnimator.GetFloat(_speedAnimatorParam.id), 
            _speedAnimatorParam.value, 
            animationBlendSpeed)
        );
        
        Quaternion currentRotation = _characterController.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, _rotationAngel, 0f);
        _characterController.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed);
    }
    
    public void Die()
    {
        _isAlive = false;

        _characterAnimator.enabled = false;
        ragDollController.Enable();
        
        OnDied?.Invoke();
    }

    private void Attack()
    {
        if (!_isAttacking)
        {
            _attackTypesRangeAnimatorParam.value = Random.Range(0f, 1f);
            _characterAnimator.SetFloat(_attackTypesRangeAnimatorParam.id, _attackTypesRangeAnimatorParam.value);
            _characterAnimator.SetTrigger(_attackAnimatorParam);
            _isAttacking = true;
        }
    }

    private void AttackEnd()
    {
        _isAttacking = false;
    }

    public void Spawn()
    {
        _characterAnimator.speed = 1;
    }
    
    private void SpawnCallback()
    {
        _spawned = true;
    }
}
