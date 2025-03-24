using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int size = 3;
    public int Size => size;

    private Item[] items;
    public  Item[] Items => items;

    private int currentItemIndex;
    public Item CurrentItem => items[currentItemIndex]; 
    public int CurrentItemIndex => currentItemIndex;

    public event Action OnInventoryChange;
    public event Action OnCurrentItemChange;

    void Awake()
    {
        items = new Item[size];
    }

    public Item FindItemByName(string itemName) {
        for(int i = 0; i < items.Length; i++) {
            if(items[i].name == itemName) {
                return items[i];
            }
        }

        return null;
    }

    public int CountItemsInInventory() {
        int nbItems = 0;
        items.ForEach((item) => {
            if(item != null) {
                nbItems++;
            }
        });

        return nbItems;
    }

    private bool AddToFirstSlotAvailable(Item newItem) {
        for(int i = 0; i < size; i++) {
            if(items[i] == null) {
                items[i] = newItem;
                if(CurrentItem == null) {
                    currentItemIndex = i;
                }
                return true;
            }
        }

        return false;
    }

    public bool AddItem(Item newItem) {
        Debug.Log("item to add :" + newItem.Name);
        if(AddToFirstSlotAvailable(newItem)) {
            Debug.Log("looted new item");
            OnInventoryChange?.Invoke();
            return true;
        } else {
            Debug.Log("cant take this now: inventory is full");
            return false;
        }
    }

    public void DropItem(Item itemToDrop) {
        // TODO
    }

    public void UseCurrentItem() {
        if(CurrentItem == null) {
            Debug.Log("no item in hand");
            return;
        }
        CurrentItem.Use();
    }

    public void DropCurrentItem() {
        Item itemToDrop = items[currentItemIndex];
        items[currentItemIndex] = null;

        Debug.Log("dorpped : " + itemToDrop.Name);
        OnInventoryChange?.Invoke();
    }

    private int FindNextSlotWithItem() {
        int itemIndexStart = (currentItemIndex + 1 + size) % size;

        for(int i = itemIndexStart; i < size; i = (i + 1) % size) {
            if(items[i] != null) {
                currentItemIndex = i;
                return i;
            }
        }

        return currentItemIndex;
    }

    public void GetNextItem() {
        int itemIndexStart = (currentItemIndex + 1 + size) % size;

        while(itemIndexStart != currentItemIndex) {
            Debug.Log("testing index = " + itemIndexStart);
            if(items[itemIndexStart] != null) {
                Debug.Log("switching to: " + CurrentItem.Name);
                currentItemIndex = itemIndexStart;
                Debug.Log("-------------");
                OnCurrentItemChange?.Invoke();
                return;
            }
            itemIndexStart = (itemIndexStart + 1) % size;
        }

        Debug.Log("no other item to switch for");
    }

    public void GetPreviousItem() {
        int itemIndexStart = (currentItemIndex - 1 + size) % size;

        while(itemIndexStart != currentItemIndex) {
            Debug.Log("testing index = " + itemIndexStart);
            if(items[itemIndexStart] != null) {
                Debug.Log("switching to: " + CurrentItem.Name);
                currentItemIndex = itemIndexStart;
                Debug.Log("-------------");
                OnCurrentItemChange?.Invoke();
                return;
            }
            itemIndexStart = (itemIndexStart - 1) % size;
        }
    }

    #region Input Actions

    public void OnUseItem(InputAction.CallbackContext context)
    {
        if(context.started) {
            UseCurrentItem();
        }
    }

    public void OnDropItem(InputAction.CallbackContext context)
    {
        if(context.started) {
            DropCurrentItem();
        }
    }

    public void OnNextItem(InputAction.CallbackContext context)
    {
        if(context.started) {
            GetNextItem();
        }
    }

    public void OnPreviousItem(InputAction.CallbackContext context) {
        if(context.started) {
            GetPreviousItem();
        }
    }

    #endregion
}
