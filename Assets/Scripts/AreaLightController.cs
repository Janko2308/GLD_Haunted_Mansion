using System.Collections;
using UnityEngine;

public class AreaLightController : MonoBehaviour
{
    public Light areaLight; // Assign this in the inspector

    private IEnumerator ActivateAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        // Turn on the light
        areaLight.enabled = true;
    }
}
