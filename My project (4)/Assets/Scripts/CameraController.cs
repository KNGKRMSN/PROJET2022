using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    private Transform player;


    private float distanceBehindPlayer = 10f;
    private float height = 0.5f;
    private float distanceToLookAtInFrontOfPlayer = 5f;
    //Private variable to store the offset distance between the player and camera

    [SerializeField] private float mouseSensitivy = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = player.position - (player.forward * distanceBehindPlayer);
        transform.position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        transform.LookAt(player.position + (player.forward * distanceToLookAtInFrontOfPlayer));

    }

    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance
    }
}
