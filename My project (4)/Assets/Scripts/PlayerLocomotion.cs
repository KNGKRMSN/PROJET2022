using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    //this is the player camera for making the reference to MousePosition()
    public GameObject playerCamera;
    //how fast can the player turn
    public float rotationSpeed;
    //how much force to apply to move.
    public float moveForce;
    //the maximum velocity change
    public float maxVelocityChange = 10.0f;
    //how high can the player jump
    public float jumpHeight;
    //gravity while jumping
    private float gravity = 9.81f;

    //This rotates the player to face the mouse position, and also locks the x and z axis.
    public void Rotator(ref Vector3 mouseWorldPosition, Transform myTransform)
    {
        MousePosition mousePosition = playerCamera.GetComponent<MousePosition>();
        mouseWorldPosition = mousePosition.mouseToWorld(mouseWorldPosition);

        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(mouseWorldPosition - myTransform.position), rotationSpeed * Time.deltaTime);
        myTransform.localEulerAngles = new Vector3(0, myTransform.localEulerAngles.y, 0);
    }
    //Moves the player local forward.
    public void Walker(Transform myTransform, Vector3 mouseWorldPosition)
    {
        float distance = Vector3.Distance(myTransform.position, mouseWorldPosition);
        if (Input.GetMouseButton(0) && distance > 0.5f)
        {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = (mouseWorldPosition - myTransform.position);
            //targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= moveForce;


            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = myTransform.GetComponent<Rigidbody>().velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            myTransform.GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);

        }
    }

    public void Jumper(Transform myTransform, bool grounded)
    {
        Vector3 velocity = myTransform.GetComponent<Rigidbody>().velocity;
        if (grounded && Input.GetKeyUp(KeyCode.Space))
            {
            GetComponent<Animation>().wrapMode = WrapMode.Once;
            GetComponent<Animation>().CrossFade("jump", 0.2f, PlayMode.StopAll);
            GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
        }
    }

    private float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}
