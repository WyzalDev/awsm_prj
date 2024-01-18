using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float interactObjectScanDistance = 4f;

    [Header("Stamina settings")]
    [SerializeField]
    private Stamina stamina;

    [SerializeField]
    private float staminaPerObject = 10f;

    // private field to store move action reference
    private InputAction moveAction;

    // assign the actions asset to this field in the inspector:
    private InputActionAsset actions;

    private Rigidbody rigidbody;

    private List<GameObject> objects;

    private Animator animator;

    private bool firstStart;

    // don't touch it
    private float myFloat;

    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        firstStart = true;
    }

    void Start() {
        firstStart = false;
        animator = transform.GetChild(0).GetComponent<Animator>();
        actions = PlayerInputController.Actions;
        moveAction = actions.FindActionMap("Player").FindAction("Movement");
        actions.FindActionMap("Player").FindAction("Interact").performed += OnInteract;
    }

    private List<GameObject> ScanObjects() {
        List<Collider> colliders = new List<Collider>(Physics.OverlapSphere(transform.position, interactObjectScanDistance));
        colliders.RemoveAll(item => !isHaveObjectsComponent(item));
        List<GameObject> result = new List<GameObject>();
        foreach(Collider collider in colliders){
            result.Add(collider.gameObject);
        }
        return result;
    }

    public bool isMoving() {
        return rigidbody.velocity.magnitude != 0;
    }

    private bool  isHaveObjectsComponent(Collider collider) {
        return collider.gameObject.GetComponent<InteractObject>() != null && collider.gameObject.GetComponent<Outline>() != null;

    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        objects = ScanObjects();
        if(objects.Count > 0) {
            animator.SetTrigger("StartInteract");
            objects[0].GetComponent<InteractObject>().OnInteract();
            Destroy(objects[0]);
            stamina.Refill(staminaPerObject);
        }
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(0,-1,0), ForceMode.VelocityChange);
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        Vector3 velocity = new Vector3(-moveVector.x, 0, -moveVector.y) * speed;
        rigidbody.velocity = velocity;
        animator.SetBool("IsMoving", velocity.magnitude != 0);
        if(moveVector.magnitude >= 0.1f) {
            float Angle = Mathf.Atan2(moveVector.y, -moveVector.x) * Mathf.Rad2Deg;
            float Smooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, Angle, ref myFloat, 0.2f);
            transform.rotation = Quaternion.Euler(0, Smooth, 0);
        }
    }

    private void OnEnable()
    {
        if(!firstStart)
            actions.FindActionMap("Player").FindAction("Interact").performed += OnInteract;
    }
    private void OnDisable()
    {
        actions.FindActionMap("Player").FindAction("Interact").performed -= OnInteract;
    }

}
