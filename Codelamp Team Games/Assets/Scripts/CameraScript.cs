using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CameraScript : MonoBehaviour
{
    [Header("PlayerInput")]
    public InputActionReference cameraInput;
    public float cameraSensitivity;

    [Header("PlayerOrientation")]
    public Transform playerBodyOrientation;

    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = cameraInput.action.ReadValue<Vector2>().x * Time.deltaTime * cameraSensitivity;
        float mouseX = cameraInput.action.ReadValue<Vector2>().y * Time.deltaTime * cameraSensitivity;

        yRotation += mouseY;
        xRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Memutar kamera dan badan
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerBodyOrientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
