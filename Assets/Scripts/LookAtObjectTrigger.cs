using System.Collections;
using UnityEngine;

public class LookAtObjectTrigger : MonoBehaviour
{
    public Camera playerCamera;
    public float lookTimeRequirement = 2.0f;
    public LayerMask layerMask;
    public Transform doorTransform;
    public float openSpeed = 90.0f;

    private float lookTimer = 0f;
    private GameObject currentObjectLookedAt;
    private bool isDoorOpen = false;
    private Quaternion originalRotation;
    private Quaternion targetRotation;

    void Start()
    {
        // Save the original rotation of the door
        originalRotation = doorTransform.rotation;
        // Calculate the target rotation based on the original rotation
        targetRotation = Quaternion.Euler(doorTransform.eulerAngles.x, doorTransform.eulerAngles.y + 90f, doorTransform.eulerAngles.z);
    }

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.transform == doorTransform)
            {
                // Increase the timer if we're looking at the door
                lookTimer += Time.deltaTime;

                if (lookTimer >= lookTimeRequirement)
                {
                    // Reset the timer
                    lookTimer = 0f;

                    // If the door is open, start closing it, otherwise start opening it
                    if (isDoorOpen)
                    {
                        StartCoroutine(RotateDoor(originalRotation));
                    }
                    else
                    {
                        StartCoroutine(RotateDoor(targetRotation));
                    }
                }
            }
            else
            {
                // Reset the timer if we look away or look at a different object
                lookTimer = 0f;
            }
        }
        else
        {
            // Reset the timer if we're not looking at anything
            lookTimer = 0f;
        }
    }

    private IEnumerator RotateDoor(Quaternion finalRotation)
    {
        // Prevent starting another coroutine if the door is already moving
        if (doorTransform.rotation != finalRotation)
        {
            float timeElapsed = 0f;
            Quaternion startRotation = doorTransform.rotation;
            float duration = Mathf.Abs(Quaternion.Angle(finalRotation, startRotation)) / openSpeed;

            while (timeElapsed < duration)
            {
                doorTransform.rotation = Quaternion.Slerp(startRotation, finalRotation, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            doorTransform.rotation = finalRotation;
            // Toggle the door state
            isDoorOpen = !isDoorOpen;
        }
    }
}
