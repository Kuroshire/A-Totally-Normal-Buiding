using UnityEngine;

[CreateAssetMenu(fileName = "Phone", menuName = "Items/Phone")]
public class PhoneItem : Item
{
    public override void Use() {
        Debug.Log("Bip bip bip");
    }
}

