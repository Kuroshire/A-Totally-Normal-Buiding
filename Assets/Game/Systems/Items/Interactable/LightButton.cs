using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : InteractableItem
{
    [SerializeField] private LightManager lightManager;

    public override void Interact()
    {
        lightManager.SetLights(!lightManager.CurrentState);
    }

    public override string GetInteractionMessage()
    {
        return lightManager.CurrentState ? "Turn off" : "Turn on";
    }
}
