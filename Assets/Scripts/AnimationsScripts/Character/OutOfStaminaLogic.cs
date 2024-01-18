using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfStaminaLogic : MonoBehaviour
{
    private Vector3 endPoint = new Vector3(0,3,0);

    private Animator animator;

    public float speed = 5f;

    private bool IsMoving = true;

    [SerializeField]
    public Rigidbody parent;

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
