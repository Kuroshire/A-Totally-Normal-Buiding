using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private ElevatorMovement movement;
    [SerializeField] private ElevatorDoors doors;

    public void Start()
    {
        doors.OnDoorsClosed += GoToDestination;
        movement.onArrivedAtFloor += ArriveAtDestination;
    }

    public void Call(Vector3 position) {
        movement.AddPositionToTargetList(position);
        doors.CloseDoors();
    }

    private void GoToDestination() {
        movement.GoToNextFloorCalled();
    }

    private void ArriveAtDestination() {
        doors.OpenDoors();
    }
}
