using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorItem : InteractableItem
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private bool isLocked = false;
    public string doorName;

    private bool canInteract = true;

    public bool IsOpen => isOpen;
    public bool IsLocked => isLocked;

    #region Door Behaviour
    private void OpenBehaviour()
    {
        isOpen = true;
        Debug.Log("Door opened");
        doorAnimator.SetBool("isOpen", true);
    }

    private void CloseBehaviour()
    {
        isOpen = false;
        Debug.Log("Door closed");
        doorAnimator.SetBool("isOpen", false);
    }

    private void TryOpenWhenLockedBehaviour() {
        UIManager.Subtitles.CallSubtitles("Door is locked... There must be a key somewhere.");
        doorAnimator.SetTrigger("isLocked");
    }

    private void UnlockBehaviour() {
        UIManager.Subtitles.CallSubtitles("Door unlocked...");
        //play sound
    }

    private void LockBehaviour() {
        UIManager.Subtitles.CallSubtitles("You locked the door...");
        //play sound
    }

    #endregion


    public void SwitchLockWithKey() {
        isLocked = !isLocked;

        if(isLocked) {
            LockBehaviour();
        } else {
            UnlockBehaviour();
        }
    }

    public override void Interact()
    {
        canInteract = false;
        if(isOpen) {
            CloseBehaviour();
        } else {
            if (!isLocked) {
                OpenBehaviour();
            } else {
                TryOpenWhenLockedBehaviour();
            }
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
