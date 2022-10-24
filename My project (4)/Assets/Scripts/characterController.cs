using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    #region variables  
    //Caches the Transform data to speed things up.
    private Transform myTransform;
    //Initializes mouseWorldPosition, gets updated in PlayerLocomotion.Rotator().
    private Vector3 mouseWorldPosition = Vector3.zero; //ref
    //True if the player is touching the ground.
    private bool grounded = false;


    #endregion


    // Use this for initialization
    void Awake()
    {
        myTransform = transform;
   //     GetComponent<Animation>().Play("idle");
    }

    // Update is called once per frame
    void Update()
    {
        //updates the player's rotation to face the mouse.
        PlayerLocomotion playerLocomotion = GetComponent<PlayerLocomotion>();
        playerLocomotion.Rotator(ref mouseWorldPosition, myTransform);
    }

    void FixedUpdate()
    {
        //this section handles walking/running and jumping.
        PlayerLocomotion playerLocomotion = GetComponent<PlayerLocomotion>();

        playerLocomotion.Walker(myTransform, mouseWorldPosition);

        playerLocomotion.Jumper(myTransform, grounded);

        //If the playerr is not colliding with floor then gorunded is false.
        grounded = false;

    }

  /*  void LateUpdate()
    {
        //This handles the animations for walking/running.
        PlayerAnim playerAnim = GetComponent<PlayerAnim>();
        playerAnim.WalkThresholds();
    }
  */
    void OnCollisionStay(Collision collisionInfo)
    {
        //if the player is colliding with the floor then grounded is true.
        grounded = true;
    }


}
