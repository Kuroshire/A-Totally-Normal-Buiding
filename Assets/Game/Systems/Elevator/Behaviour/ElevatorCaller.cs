using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorCaller : InteractableItem
{
    public Elevator elevator;
    [SerializeField] private Transform targetPosition;

    public void CallElevator() {
        elevator.Call(targetPosition.position);
    }

    override public void Interact() {
        Debug.Log("Button Pressed");
        CallElevator();
    }
}
