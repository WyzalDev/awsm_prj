using UnityEngine;

public class OutOfStaminaLogic : MonoBehaviour
{
    [SerializeField]
    public Rigidbody parent;

    private Animator animator;

    [Header("Settings")]
    [SerializeField]
    private float speed = 5f;

    private bool IsMoving = true;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if(IsMoving) {
            parent.velocity = new Vector3(speed, 0, 0);
            if(parent.transform.position.x < 0) {
                animator.SetTrigger("SleepTrigger");
                IsMoving = false;
                parent.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
            }
        }
    }
}
