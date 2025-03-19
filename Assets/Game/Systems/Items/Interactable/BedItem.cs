using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedItem : InteractableItem
{
    [SerializeField] private Transform playerBedPosition;
    [SerializeField] private FadeToBlackImage fadeToBlackImage;
    override public void Interact()
    {
        Debug.Log("Interacting with bed");
        GoToBed();

    }

    private void GoToBed()
    {
        //Fade to black
        fadeToBlackImage.BlackScreenTransition(() =>
        {
            TeleportPlayer();
        });
    }

    private void TeleportPlayer() {
        //Teleport player to bed position + rotation
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.SetPositionAndRotation(playerBedPosition.position, playerBedPosition.rotation);
    }

}
