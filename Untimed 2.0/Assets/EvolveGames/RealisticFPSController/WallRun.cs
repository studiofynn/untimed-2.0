using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    public float wallRunSpeed = 10f; // Adjust this value to change the speed of the wall run
    public float wallRunDuration = 1f; // Adjust this value to change the duration of the wall run
    public float wallRunCameraRotation = 45f; // Adjust this value to change the camera rotation during the wall run

    private CharacterController characterController; // Reference to the character controller component
    private Transform cameraTransform; // Reference to the camera transform
    private Vector3 moveDirection; // Direction of movement
    private float wallRunTimer; // Timer for the duration of the wall run

    void Start()
    {
        // Get references to the character controller and camera transform
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Check if the player is pressing the wall run button
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Check if the player is touching a wall
            if (Physics.Raycast(transform.position, transform.forward, 1f))
            {
                // Start the wall run
                wallRunTimer = wallRunDuration;
            }
        }

        // Update the wall run timer
        if (wallRunTimer > 0)
        {
            wallRunTimer -= Time.deltaTime;

            // Set the movement direction to forward and apply the wall run speed
            moveDirection = transform.forward * wallRunSpeed;

            // Rotate the camera towards the wall
            cameraTransform.rotation = Quaternion.Euler(wallRunCameraRotation, 0f, 0f);
        }
        else
        {
            // Reset the movement direction and camera rotation
            moveDirection = Vector3.zero;
            cameraTransform.rotation = Quaternion.identity;
        }

        // Apply the movement
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
