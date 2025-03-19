using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact();

    string GetInteractionMessage(); // Pour afficher un message spécifique à l'objet.
}

public class Door : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("La porte s'ouvre !");
        // Logique d'ouverture de la porte.
    }

    public string GetInteractionMessage()
    {
        return "Ouvrir la porte";
    }
}
