using System.Collections;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 10f; // Rotation speed in degrees per second

    void Update()
    {
        // Perform rotation around the up-axis (y-axis) of the GameObject
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private IEnumerator ActivateAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        // Activate the GameObject
        gameObject.SetActive(true);
    }
}
