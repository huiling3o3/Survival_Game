using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Camera mainCamera; // Reference to the main camera
    public Vector2 cameraOffset; // Offset between the player and the camera
    void Update()
    {
        // Handle player movement
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(moveX, moveY);
        transform.position += (Vector3)(moveSpeed * Time.deltaTime * move);

        // Update the camera's position to follow the player
        if (mainCamera != null)
        {
            Vector2 newCameraPosition = (Vector2)transform.position + cameraOffset;
            mainCamera.transform.position = new Vector3(newCameraPosition.x, newCameraPosition.y, mainCamera.transform.position.z);
        }
    }
}
