using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerControls playerControls;
    AnimatorManager animatorManager;

    public Vector2 movementInput;
    public Vector2 cameraInput;
    public float cameraInputX;
    public float cameraInputY;
    private float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    private void Awake() {
        animatorManager = GetComponent<AnimatorManager>();
    }
    private void OnEnable() {
        if (playerControls == null) {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }
        playerControls.Enable();
    }
    private void OnDisable() {
        playerControls.Disable();
    }

    private void handleMovementInput() {
        verticalInput =  movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);

        cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;
    }
    public void HandleAllInputs() {
        handleMovementInput();
    }
}
