using System.Collections;
using UnityEngine;

public class ActivationManager : MonoBehaviour
{
    public GameObject rotatingObject; // Assign the rotating object in the inspector
    public GameObject lightGameObject; // Assign the GameObject with the Light component in the inspector
    

    // Start is called before the first frame update
    void Start()
    {
        // Start the activation coroutine for both objects
        StartCoroutine(ActivateAfterDelay(rotatingObject, 30f)); // 60 seconds delay
        StartCoroutine(ActivateAfterDelay(lightGameObject, 30f)); // 60 seconds delay
    }

    private IEnumerator ActivateAfterDelay(GameObject objectToActivate, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        // Activate the GameObject
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
