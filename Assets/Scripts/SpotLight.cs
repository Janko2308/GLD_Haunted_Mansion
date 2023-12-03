using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLight : MonoBehaviour
{
    public Camera playerCamera;
    private float cameraVerticalAngle = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform spotlightTransform = playerCamera.transform.Find("Spotlight");
            if (spotlightTransform != null)
            {
                spotlightTransform.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
            }
        
    }
}
