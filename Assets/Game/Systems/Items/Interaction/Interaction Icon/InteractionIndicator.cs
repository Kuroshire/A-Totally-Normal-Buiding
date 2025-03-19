using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionIndicator : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;

    private void Start() {
        if(playerCamera == null) {
            playerCamera = Camera.main.transform;
        }
        Deactivate();
    }

    private void LateUpdate() {
        transform.LookAt(transform.position + playerCamera.forward);
    }

    public void Activate() {
        gameObject.SetActive(true);
    }

    public void Deactivate() {
        gameObject.SetActive(false);
    }
}
