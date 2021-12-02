using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    private float forwardInput;
    private float rightInput;
    private Vector3 velocity;
    private Quaternion rotationDirection;

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationDirection, rotationSpeed * Time.deltaTime);
    }
    public void AddMovementInput(float forward, float right) {
        forwardInput =  forward;
        rightInput = right;

        Vector3 translation = new Vector3(forwardInput, 0, rightInput);

        if (translation !=  Vector3.zero) {
            rotationDirection = Quaternion.LookRotation(translation, Vector3.up);
            velocity = translation;

        } else {
            velocity = Vector3.zero;
        }
    }
    public float GetVelocity() {
        return velocity.magnitude;
    }
}
