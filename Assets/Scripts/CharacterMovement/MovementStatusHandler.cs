using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStatusHandler : MonoBehaviour
{
    public enum MovementStatus
    {
        CanMove,
        CanNotMove,
        Dialog,
        Scene
    }

    public MovementStatus CurrentMovementStatus;

    private void Start()
    {
        CurrentMovementStatus = MovementStatus.CanMove;
    }
}
