using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ElevatorPlatform : MonoBehaviour
{
    [SerializeField] private Elevator elevator;
 
    void OnTriggerEnter(Collider other)
    {
        Transform playerTransform = IsPlayer(other);

        if(playerTransform != null)
        {
            Debug.Log("Player entered elevator platform");
            playerTransform.parent = elevator.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {   
        Transform playerTransform = IsPlayer(other);
        if(playerTransform != null)
        {
            Debug.Log("Player exited elevator platform");
            playerTransform.parent = null;
        }
    }

    private Transform IsPlayer(Collider other)
    {
        Rigidbody playerRb = other.gameObject.GetComponentInParent<Rigidbody>();
        if(playerRb != null && playerRb.CompareTag("Player")) {
            return playerRb.transform;
        }
        return null;
    }
}
