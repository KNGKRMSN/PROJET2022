using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private float currentSpeed;
    [SerializeField] private float acceleration = 0.01f;
    [SerializeField] private float decceleration = 0.05f;

    public float groundDrag;
    private float xAxisMovementReduction = 1f;
    public float gravity;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("WallRunning")]
    public bool wallruning;
    public bool moving;
    public MovementState state;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Slope")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;

    [Header("Sliding")]
    public bool sliding;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public enum MovementState
    {
        moving,
        sliding,
        wallruning
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        state = MovementState.moving;

        readyToJump = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        if (state != MovementState.wallruning)
           rb.AddForce(new Vector3(0, -1.0f, 0) * rb.mass * gravity);
    }

    private void StateHandler()
    {
        if (wallruning)
        {
            state = MovementState.wallruning;
        }
        if (moving)
        {
            state = MovementState.moving;
        }
        if (sliding)
        {
            state = MovementState.sliding;
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        
        float rotationOnTurnInDeg = 75f;

        if (horizontalInput + verticalInput > 1)
        {
                float sum = horizontalInput + verticalInput;
                float ratio = sum / 1;
                horizontalInput /= ratio;
                verticalInput /= ratio;
        }

        if ((currentSpeed < moveSpeed) && verticalInput != 0)
        {
                currentSpeed += acceleration;
        }

        if ((currentSpeed > 0) && verticalInput == 0)
        {
                currentSpeed -= decceleration;
                if (currentSpeed < 0)
                    currentSpeed = 0;
        }
        float xAxisMovement = horizontalInput * xAxisMovementReduction;
        float zAxisMovement = currentSpeed;
        // calculate movement direction
    
        moveDirection = new Vector3(xAxisMovement, 0, zAxisMovement);
        moveDirection = transform.TransformDirection(moveDirection);

        // on slope

        if (OnSlope())
        {
            rb.AddForce(GetSlopeDirection(moveDirection) * currentSpeed * 20f, ForceMode.Force);
            if (rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }

        // on ground
        if (grounded)
        {
            rb.AddForce(moveDirection, ForceMode.Force);
        }
        // in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection, ForceMode.Force);
        }
        float yAxisRotation = horizontalInput * (rotationOnTurnInDeg - currentSpeed);
        transform.Rotate(new Vector3(0, yAxisRotation, 0) * Time.deltaTime);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    public bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    public Vector3 GetSlopeDirection(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal).normalized;
    }
}