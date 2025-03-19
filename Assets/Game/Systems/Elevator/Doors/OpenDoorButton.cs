using UnityEngine;

[RequireComponent(typeof(Collider))]
public class OpenDoorButton : InteractableItem
{
    [SerializeField] private ElevatorDoors doors;

    override public void Interact() {
        Debug.Log("Button: Opening Doors...");
        doors.OpenDoors();
    }
}
