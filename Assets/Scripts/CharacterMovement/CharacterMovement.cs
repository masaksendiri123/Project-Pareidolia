using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [Header("CharacterObjectStuff")]
    public GameObject CharacterMesh;
    public CharacterController CharacterControllerComponent;
    public Transform CharacterOrientation;

    [Header("PlayerInput")]
    public InputActionReference Movement;
    public MovementStatusHandler.MovementStatus CurrentMovementStatus;

    [Header("Variables")]
    public float MovementSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Melihat Apakah Character Bisa Gerak Atau Enggak
        CurrentMovementStatus = FindObjectOfType<MovementStatusHandler>().CurrentMovementStatus;

        transform.rotation = CharacterOrientation.transform.rotation;

        float movementForwardBackward = Movement.action.ReadValue<Vector2>().y;
        float movementLeftRight = Movement.action.ReadValue<Vector2>().x;

        Vector3 movementDirection = new Vector3(movementLeftRight, 0f, movementForwardBackward);

        if(movementDirection.magnitude >= 0.1f && CurrentMovementStatus == MovementStatusHandler.MovementStatus.CanMove)
        {
            Walking(movementDirection);
        }
    }

    private void Walking(Vector3 m_moveDirection)
    {
        CharacterControllerComponent.Move((transform.right * m_moveDirection.x + transform.forward * m_moveDirection.z).normalized * Time.deltaTime * MovementSpeed);
    }
}
