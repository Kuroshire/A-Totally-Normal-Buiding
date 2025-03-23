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
            //restrict camera movement
            //restrict player movement
        });
    }

    private void TeleportPlayer() {
        //Teleport player to bed position + rotation
        Player player = PlayerManager.Player;
        player.transform.SetPositionAndRotation(playerBedPosition.position, playerBedPosition.rotation);

        Debug.Log("player forward = " + player.transform.forward);
        Debug.Log("bed forward = " + playerBedPosition.forward);

        // player.transform.forward = playerBedPosition.forward;

        player.lookAround.SwitchToRestricted180Degrees(playerBedPosition.forward);
    }

}
