using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{   
    InputManager inputManager;
    CameraManager cameraManager;
    PlayerLocomotion playerLocomotion;
    private void Awake() {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        cameraManager = FindObjectOfType<CameraManager>();
    }
    private void Update() {
        inputManager.HandleAllInputs();
    }
    private void FixedUpdate() {
        playerLocomotion.handleAllMovement();
    }
    private void LateUpdate() {
        cameraManager.HandleAllCameraMovement();
    }
}
