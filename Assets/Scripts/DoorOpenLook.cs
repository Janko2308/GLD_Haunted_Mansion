using UnityEngine;

public class DoorOpenLook : MonoBehaviour
{
    public float requiredLookTime = 5.0f; // Time the player needs to look at the door to open it
    public float openSpeed = 90.0f; // Speed at which the door opens
    public Camera playerCamera; // The player's camera, assign in inspector
    public Transform doorTransform; // The transform of the door, assign in inspector

    private float lookTimer = 0f;
    private bool isDoorOpen = false;
    private float currentYRotation = 0f;
    private float targetYRotation = 90f;

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.yellow); // Adjust the length as needed

        if (Physics.Raycast(ray, out hit) && hit.transform == doorTransform)
        {
            // Increment the timer if the player is looking at the door
            lookTimer += Time.deltaTime;
            Debug.Log("Looking at door for " + lookTimer + " seconds");

            if (lookTimer >= requiredLookTime && !isDoorOpen)
            {
                // Start opening the door
                isDoorOpen = true;
                Debug.Log("Door opened!");
            }
        }
        else
        {
            // Reset the timer if the player looks away
            lookTimer = 0f;
        }

        // If the door is marked as opening, rotate it smoothly to open
        if (isDoorOpen)
        {
            currentYRotation = Mathf.MoveTowards(currentYRotation, targetYRotation, openSpeed * Time.deltaTime);
            doorTransform.localEulerAngles = new Vector3(doorTransform.localEulerAngles.x, currentYRotation, doorTransform.localEulerAngles.z);

            // Stop the script if the door is fully open
            if (currentYRotation == targetYRotation)
            {
                this.enabled = false;
            }
        }
    }
}