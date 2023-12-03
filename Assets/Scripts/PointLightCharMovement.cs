using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightCharMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float speed = 1.0f;
    public float height = 1.0f;
    public float turnSpeed = 1500.0f; // Increased speed at which the player turns
    public float cameraVerticalSpeed = 1000.0f; // Increased speed of vertical camera movement
    private Rigidbody rb;
    private float cameraVerticalAngle = 0.0f;
    private float cameraVerticalRange = 80.0f; // Limit for the camera's vertical rotation

    void Start()
    {
        // Ensure there's a Rigidbody component attached for physics calculations
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false; // Disable gravity as the light will float
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // Prevent Rigidbody from rotating along X and Z axes
        }
    }

    void Update()
    {
        // Check if right mouse button is held down
        if (Input.GetMouseButton(1)) // Right mouse button held down
        {
            // Rotate player based on horizontal mouse movement
            float horizontalRotation = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
            transform.Rotate(0, horizontalRotation, 0);

            // Camera vertical rotation
            float verticalRotation = Input.GetAxis("Mouse Y") * cameraVerticalSpeed * Time.deltaTime;
            cameraVerticalAngle -= verticalRotation;
            cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -cameraVerticalRange, cameraVerticalRange);
            playerCamera.transform.localEulerAngles = new Vector3(cameraVerticalAngle, playerCamera.transform.localEulerAngles.y, 0);

            // Assuming the spotlight is a direct child of the camera
            // This keeps the spotlight aligned with the camera's forward vector
            Transform spotlightTransform = playerCamera.transform.Find("Spotlight");
            if (spotlightTransform != null)
            {
                spotlightTransform.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
            }
        }
    }

    void FixedUpdate()
    {
    // Basic WASD movement
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    Vector3 movement = transform.forward * moveVertical + transform.right * moveHorizontal;
    rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);

    // Adjust height to maintain a specific distance from the ground
    RaycastHit hit;
    if (Physics.Raycast(transform.position, -Vector3.up, out hit))
    {
        Debug.DrawRay(transform.position, -Vector3.up * hit.distance, Color.red); // Visualize the raycast

        if (hit.collider.tag != "NonClimbable") // Replace with your tag name
        {
            // Adjust height if not over a NonClimbable object
            AdjustHeight(hit);
        }
        else
        {
            // Handle behavior when over a NonClimbable object
            HandleNonClimbableSurface(hit);
        }
    }

    void AdjustHeight(RaycastHit hit)
    {
        float currentHeight = hit.distance;
        if (currentHeight != height) // If not at desired height
        {
            float heightDifference = height - currentHeight;
            Vector3 newPosition = transform.position;
            newPosition.y += heightDifference;
            transform.position = newPosition;
        }
    }

    void HandleNonClimbableSurface(RaycastHit hit)
    {
        // Example: Stop vertical movement
        if (hit.distance < height)
        {
            // If below the designated height, maintain current height
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
        // Optionally, handle cases where the player is above the designated height
        // This part depends on your game's desired behavior
    }
    }
}