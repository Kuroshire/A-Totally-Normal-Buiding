using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "Items/Door Key")]
public class KeyItem : Item
{
    public string doorToOpenName;

    public override void Use() {
        if(doorToOpenName == null) {
            Debug.Log("door to open doesn't exist...");
            return;
        }

        //if player looking at door
        if(!InteractWithDoor()){
            Debug.Log("La clé ouvre : " + doorToOpenName);
        }
    }

    private bool InteractWithDoor() {
        InteractableItem currentItemInteracted = PlayerManager.PlayerCurrentInteractableSelection;

        if(currentItemInteracted == null) {
            Debug.Log("no item to interact with...");
            return false;
        }

        if(currentItemInteracted.GetType() != typeof(DoorItem)) {
            Debug.Log("Not a door...");
            return false;
        }

        if( ((DoorItem) currentItemInteracted).doorName != doorToOpenName) {
            Debug.Log("Wrong door...");
            return false;
        }

        ((DoorItem) currentItemInteracted).SwitchLockWithKey();
        return true;
        
    }
}
