using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "Items/Door Key")]
public class KeyItem : Item
{
    public string doorToOpen;

    public override void Use() {
        Debug.Log("La clé ouvre : " + doorToOpen);
    }
}
