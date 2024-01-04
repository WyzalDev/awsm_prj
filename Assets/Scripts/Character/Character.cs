using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
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

    private float scanUsingObjects = 1f;

    private List<GameObject> objects;

    float myFloat;

    void Awake() {
        moveAction = actions.FindActionMap("Player").FindAction("Movement");
        actions.FindActionMap("Player").FindAction("Interact").performed += OnInteract;
        rigidbody = GetComponent<Rigidbody>();
    }

    private List<GameObject> ScanObjects() {
        List<Collider> colliders = new List<Collider>(Physics.OverlapSphere(transform.position, scanUsingObjects));
        colliders.RemoveAll(item => !isHaveObjectsComponent(item));
        List<GameObject> result = new List<GameObject>();
        foreach(Collider collider in colliders){
            result.Add(collider.gameObject);
        }
        return result;
    }

    private bool  isHaveObjectsComponent(Collider collider){
        return collider.gameObject.GetComponent<Outline>() != null;

    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        objects = ScanObjects();
        if(objects.Count > 0){
            Destroy(objects[0]);
        }
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
