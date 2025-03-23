using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundMakerItem : InteractableItem
{
    [SerializeField] private AudioSource audioSource;
    
    override public void Interact()
    {
        Debug.Log("Interacting with sound maker");
        audioSource.Play();
    }
}
