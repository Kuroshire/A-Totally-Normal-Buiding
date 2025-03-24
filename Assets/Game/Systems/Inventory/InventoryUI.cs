using System.Runtime.CompilerServices;
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
        inventory.OnCurrentItemChange += ShowItemsInInventory;
    }

    public void ShowItemsInInventory() {
        Item[] items = inventory.Items;

        int currentItemIndex = inventory.CurrentItemIndex;
        for(int slotIndex = 0; slotIndex < inventorySlots.Length; slotIndex++) {
            if(items[currentItemIndex] != null) {
                inventorySlots[slotIndex].sprite = items[currentItemIndex].UISprite;
            } else {
                inventorySlots[slotIndex].sprite = null;
            }
            currentItemIndex = (currentItemIndex + 1) % inventory.Size;
        }
    }
}