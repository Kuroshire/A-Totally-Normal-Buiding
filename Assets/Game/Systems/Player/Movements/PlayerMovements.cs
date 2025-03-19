using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speed = 5;
    private Vector3 _moveDirection;

    [SerializeField] private float jumpForce = 5;
    [SerializeField] private Transform feetPosition;
    private bool isGrounded = false;

    void Update()
    {
        CheckIfGrounded();
    }

    private void FixedUpdate() {
        float accurateMoveSpeed = speed * Time.fixedDeltaTime;
        Vector3 accurateMovement = GetMovementDirectionBasedOnCamera() * accurateMoveSpeed;

        rb.velocity = new Vector3(accurateMovement.x, rb.velocity.y, accurateMovement.z);
    }

    private Vector3 GetMovementDirectionBasedOnCamera() {
        Vector3 playerForward = rb.transform.forward;
        Vector3 playerRight = rb.transform.right;
        return playerForward * _moveDirection.y + playerRight * _moveDirection.x;
    }

    private void CheckIfGrounded() {
        isGrounded = Physics.Raycast(feetPosition.position, Vector3.down, 0.1f);
    }

    private void Move(Vector2 moveDirection) {
        _moveDirection = moveDirection;
    }

    public void OnMoveAction(InputAction.CallbackContext context) {
        Move(context.ReadValue<Vector2>());
    }

    public void OnJumpAction(InputAction.CallbackContext context) {
        Debug.Log("is grounded: " + isGrounded);
        Debug.Log("context performed: " + context.performed);
        if(isGrounded) {
            if(context.performed) {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
