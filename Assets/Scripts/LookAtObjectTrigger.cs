using System.Collections;
using UnityEngine;

public class LookAtObjectTrigger : MonoBehaviour
{
    public Camera playerCamera;
    public float lookTimeRequirement = 2.0f;
    public LayerMask layerMask;
    public Transform doorTransform;
    public Transform doorTransform2;
    public float openSpeed = 90.0f;

    private float lookTimer = 0f;
    private float lookTimer2 = 0f;
    private bool isDoorOpen = false;
    private bool isDoorOpen2 = false;
    private Quaternion originalRotation;
    private Quaternion targetRotation;
    private Quaternion originalRotation2;
    private Quaternion targetRotation2;

    void Start()
    {
        // Save the original rotation of the first door
        originalRotation = doorTransform.rotation;
        targetRotation = Quaternion.Euler(doorTransform.eulerAngles.x, doorTransform.eulerAngles.y + 90f, doorTransform.eulerAngles.z);

        // Save the original rotation of the second door
        originalRotation2 = doorTransform2.rotation;
        targetRotation2 = Quaternion.Euler(doorTransform2.eulerAngles.x, doorTransform2.eulerAngles.y + 90f, doorTransform2.eulerAngles.z);
    }

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // Check if we're looking at the first door
            if (hit.transform == doorTransform)
            {
                HandleDoor(ref lookTimer, ref isDoorOpen, doorTransform, originalRotation, targetRotation);
            }
            // Check if we're looking at the second door
            else if (hit.transform == doorTransform2)
            {
                HandleDoor(ref lookTimer2, ref isDoorOpen2, doorTransform2, originalRotation2, targetRotation2);
            }
            else
            {
                ResetTimers();
            }
        }
        else
        {
            ResetTimers();
        }
    }

    private void HandleDoor(ref float timer, ref bool doorState, Transform door, Quaternion originalRot, Quaternion targetRot)
    {
        timer += Time.deltaTime;

        if (timer >= lookTimeRequirement)
        {
            timer = 0f;
            Quaternion finalRotation = doorState ? originalRot : targetRot;
            StartCoroutine(RotateDoor(door, finalRotation));
            doorState = !doorState; // Toggle the door state
        }
    }

    private IEnumerator RotateDoor(Transform door, Quaternion finalRotation)
    {
        float timeElapsed = 0f;
        Quaternion startRotation = door.rotation;
        float duration = Mathf.Abs(Quaternion.Angle(finalRotation, startRotation)) / openSpeed;

        while (timeElapsed < duration)
        {
            door.rotation = Quaternion.Slerp(startRotation, finalRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        door.rotation = finalRotation;
    }

    private void ResetTimers()
    {
        lookTimer = 0f;
        lookTimer2 = 0f;
    }
}
