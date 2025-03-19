using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSensitivity = 100;
    private float xRotation = 0;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        LookAround();
    }

    private void LookAround() {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector2 mouseDelta = mouseInput * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseDelta.y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseDelta.x);
    }
}
