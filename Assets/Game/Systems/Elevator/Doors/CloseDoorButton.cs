using UnityEngine;

public class CloseDoorButton : InteractableItem
{
    [SerializeField] private ElevatorDoors doors;

    override public void Interact() {
        Debug.Log("Button: Closing Doors...");
        doors.CloseDoors();
    }
}
