using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private Vector3 _moveDir;
    private CharacterController _characterController;

    [Header("Velocidade")]
    public float speed = 5f;
    public float speedRun = 1f;
    private bool isRun = false;

    [Header("Gravidade")]
    private float _gravity = -9.81f;
    public float gravityMultiplier = 3f;
    private float _velocityY;

    [Header("Rotação")]
    public float rotationSmoothTime = 0.1f;
    private float _rotationVelocity;

    private Camera _mainCamera;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (
            CanvasGameManager.EndGame.IsEndGame == true || 
            CarMng.CarController.EnableCar == true ||
            CanvasGameManager.Instance.isGamePaused == true
        ) return;

        ApplyMovement();
        ApplyGravity();
        ApplyRun();
    }

    private void ApplyGravity()
    {
        if (_characterController.isGrounded && _velocityY < 0.0f)
        {
            _velocityY = -1f;
        }
        else
        {
            _velocityY += _gravity * gravityMultiplier * Time.deltaTime;
        }
    }

    private void ApplyMovement()
    {
        if (_input.sqrMagnitude > 0.01f)
        {
            Vector3 camForward = _mainCamera.transform.forward;
            Vector3 camRight = _mainCamera.transform.right;
            camForward.y = 0;
            camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();

            _moveDir = (camForward * _input.y + camRight * _input.x).normalized;

            float targetAngle = Mathf.Atan2(_moveDir.x, _moveDir.z) * Mathf.Rad2Deg;
            float smoothAngle = Mathf.SmoothDampAngle(
                transform.eulerAngles.y,
                targetAngle,
                ref _rotationVelocity,
                rotationSmoothTime
            );

            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
        }
        else
        {
            _moveDir = Vector3.zero;
        }

        Vector3 move = _moveDir * speed * speedRun * Time.deltaTime;
        move.y = _velocityY * Time.deltaTime;

        _characterController.Move(move);

        if (_input.sqrMagnitude < 0.01f)
        {
            PlayerManager.Animation.PlayIdle();
        }
        else
        {
            if (isRun)
                PlayerManager.Animation.PlayRun();
            else
                PlayerManager.Animation.PlayWalk();
        }
    }

    private void ApplyRun()
    {
        if (isRun)
        {
            if (speedRun < 2)
                speedRun += Time.deltaTime * speed;
            else
                speedRun = 2;
        }
        else
        {
            if (speedRun > 1)
                speedRun -= Time.deltaTime * speed;
            else
                speedRun = 1;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();        
    }

    public void Run(InputAction.CallbackContext context)
    {
        if (context.started)
            isRun = true;

        if (context.canceled)
            isRun = false;
    }
}
