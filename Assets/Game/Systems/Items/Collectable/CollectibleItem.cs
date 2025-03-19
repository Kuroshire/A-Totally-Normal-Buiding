using UnityEngine;

public class CollectibleItem : InteractableItem
{

    [SerializeField] public Item item;
    public override void Interact()
    {
        Debug.Log(PlayerManager.PlayerInventory ? "exist" : "doesn't exist");
        if(PlayerManager.PlayerInventory.AddItem(item)) {
            Debug.Log("collected item: " + item.Name);
            Destroy(gameObject);
        } else {
            Debug.Log("Inventory is full...");
        }
    }
}