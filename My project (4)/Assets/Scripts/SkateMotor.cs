using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SkateMotor : MonoBehaviour
{/*

    bool isGrounded = true;
    public float gravity = -9f;
    private float acceleration = 0.01f;
    private float decceleration = 0.05f;
    private float currentSpeed = 2f;
    private float startSpeed = 2f;
    private float maxSpeed = 40f;
    private float rotationOnTurnInDeg = 75f;
    private float xAxisMovementReduction = 1f;
    public float jumpForce = 200f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float dirY = 0;

        if (inputX + inputY > 1)
        {
            float sum = inputX + inputY;
            float ratio = sum / 1;
            inputX /= ratio;
            inputY /= ratio;
        }
        if ((currentSpeed < maxSpeed) && inputY != 0)
        {
            currentSpeed += acceleration;
        }

        if ((currentSpeed > 0) && inputY == 0)
        {
            currentSpeed -= decceleration;
            if (currentSpeed < 0)
                currentSpeed = 0;
        }

        float xAxisMovement = inputX * xAxisMovementReduction;
        float zAxisMovement = currentSpeed;
        Vector3 moveDirection;

        moveDirection = new Vector3(xAxisMovement, 0, zAxisMovement) * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Entered");
            dirY += jumpForce;
        }
        dirY -= gravity * Time.deltaTime;
        moveDirection.y = dirY;

        GetComponent<CharacterController>().Move(transform.TransformDirection(moveDirection));

        float yAxisRotation = inputX * rotationOnTurnInDeg;
        transform.Rotate(new Vector3(0, yAxisRotation, 0) * Time.deltaTime);

        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }*/
}