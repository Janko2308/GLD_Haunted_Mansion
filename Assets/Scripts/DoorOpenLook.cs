using UnityEngine;

public class DoorOpenLook : MonoBehaviour
{
    public float requiredLookTime = 5.0f;
    public float openSpeed = 90.0f;
    public Camera playerCamera;
    public Transform doorTransform;
    public bool isDoorOpen = false;
    public float targetYRotation;

    private float lookTimer = 0f;
    private float currentYRotation = 0f;
    //private float targetYRotation = 90f;

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.transform == doorTransform)
        {
            lookTimer += Time.deltaTime;
            Debug.Log("Looking at door for " + lookTimer + " seconds.");
            if (lookTimer >= requiredLookTime && !isDoorOpen)
            {
                isDoorOpen = true;
                Debug.Log("Door opened!");
                lookTimer = 0f;
            }
            else if(lookTimer >= requiredLookTime && isDoorOpen)
            {
                isDoorOpen = false;
                Debug.Log("Door closed!");
                lookTimer = 0f;
            }
        }
        else
        {
            lookTimer = 0f;
        }

        if (isDoorOpen)
        {
            currentYRotation = Mathf.MoveTowards(currentYRotation, targetYRotation, openSpeed * Time.deltaTime);
            doorTransform.localEulerAngles = new Vector3(doorTransform.localEulerAngles.x, currentYRotation, doorTransform.localEulerAngles.z);

            if (currentYRotation == targetYRotation)
            {
                this.enabled = false;
            }
        }
    }

}
