using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnOffFlashlightScript : MonoBehaviour
{
    [Header("FlashlightInput")]
    public InputActionReference FlasLightToggle;

    [Header("FlashlightObject")]
    public Light Flaslight;
    public Transform CameraTransform;

    //Start is called before the first frame update
    private void Awake()
    {
        FlasLightToggle.action.performed += ToggleFlashlight;
    }

    private void OnDestroy()
    {
        FlasLightToggle.action.performed -= ToggleFlashlight;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = CameraTransform.transform.rotation;
    }

    void ToggleFlashlight(InputAction.CallbackContext context)
    {
        if (Flaslight.enabled == true)
        {
            Flaslight.enabled = false;
        }
        else
        {
            Flaslight.enabled = true;
        }
    }
}
