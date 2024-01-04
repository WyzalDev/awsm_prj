using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    // assign the actions asset to this field in the inspector:
    public InputActionAsset actions;

    public float speed = 10f;
    // private field to store move action reference
    private InputAction moveAction;

    private Rigidbody rigidbody;

    float myFloat;

    void Awake() {
        moveAction = actions.FindActionMap("Player").FindAction("Movement");
        actions.FindActionMap("Player").FindAction("Interact").performed += OnInteract;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Interact!");
    }

    void FixedUpdate()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        Debug.Log(moveVector);
        rigidbody.velocity = new Vector3(-moveVector.x, 0, -moveVector.y) * speed;
        if(moveVector.magnitude >= 0.1f) {
            float Angle = Mathf.Atan2(moveVector.y, -moveVector.x) * Mathf.Rad2Deg;
            float Smooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, Angle, ref myFloat, 0.2f);
            transform.rotation = Quaternion.Euler(0, Smooth, 0);
        }
    }

    void OnEnable()
    {
        actions.FindActionMap("Player").Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap("Player").Disable();
    }
}
