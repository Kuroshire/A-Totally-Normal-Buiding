using UnityEngine.UI;
using Sirenix.Utilities;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] PlayerInventory inventory;
    [SerializeField] Image[] inventorySlots;

    void Awake()
    {
        inventory.OnInventoryChange += ShowItemsInInventory;
    }

    public void ShowItemsInInventory() {
        Item[] items = inventory.Items;
        for(int i = inventory.CurrentItemIndex; i < inventory.Size; i+= 1 % inventory.Size) {
            if(items[i] != null) {
                inventorySlots[i].sprite = items[i].UISprite;
            }
        }
    }
}