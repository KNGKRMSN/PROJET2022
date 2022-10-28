using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public class Player : MonoBehaviour
{
    public enum MovementMode
    {
        wallRunning,
        Strafe
    }

    [SerializeField]
    private MovementMode _movementMode = MovementMode.Strafe;
    [SerializeField]
    private float _walkSpeed = 20f;
    [SerializeField]
    private float _runningSpeed = 40f;
    [SerializeField]
    private float _gravity = 9.81f;
    [SerializeField]
    private float _gravityPlatformer = -12f;
    [SerializeField]
    private float _jumpSpeed = 3.5f;
    [SerializeField]
    private float _doubleJumpMultiplier = 1f;
    [SerializeField]
    private GameObject _cameraRig;
    private float acceleration = 0.01f;
    private float decceleration = 0.05f;
    private float xAxisMovementReduction = 1f;

    public float jumpHeight = 1;

    private CharacterController _controller;

    private float _directionY;
    private float currentSpeed;

    private bool _canDoubleJump = false;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.01f;
    float speedSmoothVelocity;

    private float velocityY;

    public bool wallrunning = false;

    public float walljumpforce = 0f;

    WallRunning wr;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        wr = GetComponent<WallRunning>();
    }

    void Update()
    {
        if (_movementMode == MovementMode.Strafe)
        {
            MovementStafe();
        }

        if (_movementMode == MovementMode.wallRunning)
        {
            wallrunning = true;
        }
    }

    private void LateUpdate()
    {
        if (IsPlayerMoving() && _movementMode == MovementMode.Strafe)
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _cameraRig.transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    private bool IsPlayerMoving()
    {
        return Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
    }

    public void MovementStafe()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float rotationOnTurnInDeg = 75f;

       if (horizontalInput + verticalInput > 1)
       {
           float sum = horizontalInput + verticalInput;
           float ratio = sum / 1;
           horizontalInput /= ratio;
           verticalInput /= ratio;
       }

    
        
        if (_controller.isGrounded)
        {
            
            walljumpforce = 0f;
            _canDoubleJump = true;

            if (Input.GetButtonDown("Jump"))
            {
                _directionY = _jumpSpeed;
            }
        }
        else
        {
            if (wallrunning)
            {
                _canDoubleJump = true;
            }

            if (Input.GetButtonDown("Jump") && _canDoubleJump)
            {
                if (wallrunning)
                {
                    if (wr.wallLeft)
                        walljumpforce = 20f;
                    if (wr.wallRight)
                        walljumpforce = -20f;

                }
             else
                 walljumpforce = 0f;
                Debug.Log("Hello");
                _directionY = _jumpSpeed * _doubleJumpMultiplier;
                _canDoubleJump = false;
            }
        }

        _directionY -= _gravity * Time.deltaTime;

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = (running) ? _runningSpeed : _walkSpeed;

        if ((currentSpeed < targetSpeed) && verticalInput != 0)
        {
            currentSpeed += acceleration;
        }

        if ((currentSpeed > 0) && verticalInput == 0)
        {
            Debug.Log("G");
            currentSpeed -= decceleration;
            if (currentSpeed < 0)
                currentSpeed = 0;
        }
        float xAxisMovement = horizontalInput * xAxisMovementReduction + walljumpforce;
        float zAxisMovement = currentSpeed;

        Vector3 moveDirection = new Vector3(xAxisMovement, 0, zAxisMovement);
        moveDirection = transform.TransformDirection(moveDirection);

        moveDirection.y = _directionY;

        _controller.Move(Time.deltaTime * moveDirection);

        float yAxisRotation = horizontalInput * rotationOnTurnInDeg;
        transform.Rotate(new Vector3(0, yAxisRotation, 0) * Time.deltaTime);
    }
    
}*/
