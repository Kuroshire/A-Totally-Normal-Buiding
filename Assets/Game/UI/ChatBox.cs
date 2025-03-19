using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatBox : MonoBehaviour
{
    [SerializeField] private GameObject chatBoxUI;
    [SerializeField] private TextMeshProUGUI chatText;

    public void DisplayMessage(string message)
    {
        chatText.text = message;
        chatBoxUI.SetActive(true);
    }

    public void Hide()
    {
        chatBoxUI.SetActive(false);
    }
}
