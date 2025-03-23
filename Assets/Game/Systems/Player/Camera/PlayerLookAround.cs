using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSensitivity = 100;
    private float xRotation = 0, yRotation = 0;

    private LookAroundMode lookAroundMode = LookAroundMode.Default;

    private Vector3 forwardReferal;

    public void SwitchToRestricted180Degrees(Vector3 forward) {
        lookAroundMode = LookAroundMode.Restricted180Degrees;
        forwardReferal = forward;

        xRotation = 0; 
    }

    public void SwitchToDefaultLookAround() {
        lookAroundMode = LookAroundMode.Default;
        
        xRotation = 0;
    }

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        switch(lookAroundMode) {
            case LookAroundMode.Restricted180Degrees:
                LookAround180DegreesOnly();
                break;
            case LookAroundMode.Default:
            default:
                LookAroundDefault();
                break;
        }
    }

    private void LookAroundDefault() {
        Vector2 mouseInput = new(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector2 mouseDelta = mouseSensitivity * Time.deltaTime * mouseInput;

        xRotation -= mouseDelta.y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseDelta.x);
    }

    private void LookAround180DegreesOnly() {
        Vector2 mouseInput = new(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector2 mouseDelta = mouseSensitivity * Time.deltaTime * mouseInput;



        // Track the current rotation angles
        xRotation = transform.eulerAngles.y;
        yRotation = transform.eulerAngles.x;

        Debug.Log("rotation: " + transform.eulerAngles);

        if (xRotation > 90) xRotation -= 360;

        if(xRotation >= -180 && xRotation <= 0) {
            //rotate
            Debug.Log("rotate x: " + xRotation);
            transform.Rotate(Vector3.up * mouseDelta.x, Space.World); // xRotation (left/right)
        } else {
            transform.eulerAngles = new(transform.eulerAngles.x, Mathf.Clamp(xRotation, -180, 0), transform.eulerAngles.z);
        }

        if (yRotation > 180) yRotation -= 360;

        if(yRotation >= 0 && yRotation <= 80) {
            transform.Rotate(Vector3.left * mouseDelta.y, Space.Self); // yRotation (up/down)
        } else {
            transform.eulerAngles = new(Mathf.Clamp(yRotation, 0, 80), transform.eulerAngles.y, transform.eulerAngles.z);
        }

        // Clamp yRotation (up/down) and xRotation (left/right)
        yRotation = Mathf.Clamp(yRotation, 0, 80);
        xRotation = Mathf.Clamp(xRotation, -90, 90);
    }
}

public enum LookAroundMode {
    Default, 
    Restricted180Degrees
}
