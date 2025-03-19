using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class InteractableItem : MonoBehaviour, IInteractable
{
    public InteractionIndicator icon;

    private void Start()
    {
        icon.Deactivate();
    }

    public void OnFocus()
    {
        if(!CanInteract()) return;
        icon.Activate();
    }

    public void OnUnfocus()
    {
        icon.Deactivate();
    }
    
    public abstract void Interact();

    public virtual bool CanInteract() { return true; }

    public virtual string GetInteractionMessage() { return "Interact"; }
}