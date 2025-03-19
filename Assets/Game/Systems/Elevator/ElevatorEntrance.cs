using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorEntrance : MonoBehaviour
{
    [SerializeField] ElevatorDoors doors;

    public void OpenDoors() {
        doors.OpenDoors();
    }
}
