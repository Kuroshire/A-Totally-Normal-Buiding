using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationalNPC : InteractableItem
{
    [SerializeField] private string[] conversationLines;
    [SerializeField] private int currentLineIndex = 0;

    [SerializeField] private ChatBox chatBox;

    private bool isInteractable = true;

    public override void Interact()
    {
        if(!CanInteract()) return;

        Debug.Log("Interacting with NPC");
        // Start a conversation
        StartConversation();
    }

    private void StartConversation()
    {
        // If there are no more lines, end the conversation
        if (currentLineIndex >= conversationLines.Length)
        {
            EndConversation();
            return;
        }

        // Display the current line of conversation
        chatBox.DisplayMessage(conversationLines[currentLineIndex]);
        currentLineIndex++;
    }

    private void EndConversation()
    {
        // Hide the chat box
        chatBox.Hide();
        currentLineIndex = 0;
        isInteractable = false;
    }

    public override bool CanInteract() {
        return isInteractable;
    } 

    public override string GetInteractionMessage()
    {
        return CanInteract() ? "Talk" : "End Conversation";
    }
}
