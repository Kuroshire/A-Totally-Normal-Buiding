using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorItem : InteractableItem
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private bool isLocked = false;
    private bool canInteract = true;

    public bool IsOpen => isOpen;
    public bool IsLocked => isLocked;

    private void Open()
    {
        if (!isLocked)
        {
            isOpen = true;
            Debug.Log("Door opened");
            doorAnimator.SetBool("isOpen", true);
        }
        else
        {
            UIManager.Subtitles.CallSubtitles("Door is locked... There must be a key somewhere.");
            doorAnimator.SetTrigger("isLocked");
        }
    }

    private void Close()
    {
        isOpen = false;
        Debug.Log("Door closed");
        doorAnimator.SetBool("isOpen", false);
    }

    public override void Interact()
    {
        canInteract = false;
        if(isOpen) {
            Close();
        } else {
            Open();
        }
        Invoke(nameof(ReactivateInteraction), 1f);
    }

    public override bool CanInteract() {
        return canInteract;
    }

    private void ReactivateInteraction() {
        canInteract = true;
    }
}
