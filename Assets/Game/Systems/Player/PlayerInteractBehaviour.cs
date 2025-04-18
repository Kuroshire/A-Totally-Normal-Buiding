using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractBehaviour: MonoBehaviour {
    public float interactionRange = 3f;
    private InteractableItem currentInteractable = null;

    public InteractableItem CurrentInteractable => currentInteractable;

    void FixedUpdate()
    {
        HandleInteractionDetection();
    }

    void HandleInteractionDetection()
    {
        Ray ray = new(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange))
        {
            if (hit.collider.TryGetComponent<InteractableItem>(out var interactable)) {
                SwitchCurrentInteractable(interactable);
            }
            else {
                SwitchCurrentInteractable(null);
            }
        } else {
            SwitchCurrentInteractable(null);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * interactionRange);
    }

    private void SwitchCurrentInteractable(InteractableItem newInteractable) {
        if(currentInteractable != null) {
            currentInteractable.OnUnfocus();
        }
        
        if(newInteractable == null) {
            currentInteractable = null;
            return;
        }
        
        currentInteractable = newInteractable;
        currentInteractable.OnFocus();
    }

    void InteractWithObject()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    public void OnInteractAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InteractWithObject();
        }
    }
}
