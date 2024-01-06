using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Companion : MonoBehaviour
{
    public Character character;

    private Rigidbody rigidbody;

    private CompanionState state;

    private CompanionState lastIdleState = CompanionState.Idle;

    public float speed = 10f;

    public float pursuingDistance = 3f;

    public float safeDistance = 1f;

    private float distance = 0f;

    private Vector2 characterDirection;

    private Vector2 randomDirection;

    public float cooldownChangeInDistanceBehaviour = 2f;

    public float randomDirectionCooldown = 1f;

    private float nextRadomDirectionTime;

    private float nextChangeInDistanceBehaviour;

    // don't touch it
    float myFloat;

    void Awake() {
        rigidbody = GetComponent<Rigidbody>();   
    }

    void Start() {
        nextChangeInDistanceBehaviour = cooldownChangeInDistanceBehaviour;
        nextRadomDirectionTime = randomDirectionCooldown;
        randomDirection = new Vector2(Random.Range(-1,1), Random.Range(-1,1)).normalized;
    }

    void FixedUpdate() {
        ChangeCharacterAndCircleDirection();

        distance = Vector2.Distance(
            VectorUtility.Vector3ToVector2WithoutOneAxis(transform.position, Axis.y),
            VectorUtility.Vector3ToVector2WithoutOneAxis(character.transform.position, Axis.y));

        nextChangeInDistanceBehaviour = Mathf.Clamp(nextChangeInDistanceBehaviour - Time.fixedDeltaTime, 0, cooldownChangeInDistanceBehaviour);
        nextRadomDirectionTime = Mathf.Clamp(nextRadomDirectionTime - Time.fixedDeltaTime, 0, randomDirectionCooldown);

        if (nextRadomDirectionTime == 0) {
            randomDirection = new Vector2(Random.Range(-1,1), Random.Range(-1,1)).normalized;
            nextRadomDirectionTime = randomDirectionCooldown;
        }

        if(distance > pursuingDistance){
            state = CompanionState.Pursuing;
        } else {
            if(nextChangeInDistanceBehaviour == 0) {
                ChangeLastIdleState();
                nextChangeInDistanceBehaviour = cooldownChangeInDistanceBehaviour;
            }
            if(distance <= pursuingDistance - safeDistance)
                state = lastIdleState;
        }
        ExcuteBehaviour();

    }

    private void ChangeCharacterAndCircleDirection() {
        characterDirection = (
            VectorUtility.Vector3ToVector2WithoutOneAxis(transform.position, Axis.y)
            -VectorUtility.Vector3ToVector2WithoutOneAxis(character.transform.position, Axis.y)
        ).normalized;
        
    }

    private void ChangeLastIdleState() {
        if(lastIdleState == CompanionState.Idle) {
            lastIdleState = CompanionState.RunAround;
        } else {
            lastIdleState = CompanionState.Idle;
        }
    }

    private void ExcuteBehaviour() {
        switch(state) {
            case CompanionState.Pursuing : {
                Move(characterDirection);
                break;
            }
            case CompanionState.RunAround : {
                Move(randomDirection);
                break;
            }
            //CompanionState.Idle says that nothing should happen
        }
    }

    private void Move(Vector2 direction) {
        rigidbody.AddForce(new Vector3(-direction.x, 0, -direction.y) * speed);

        if(direction.magnitude >= 0.1f) {
            float Angle = Mathf.Atan2(direction.y, -direction.x) * Mathf.Rad2Deg;
            float Smooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, Angle, ref myFloat, 0.3f);
            transform.rotation = Quaternion.Euler(0, Smooth, 0);
        }
    }

}

public enum CompanionState {

    Pursuing,
    Idle,
    RunAround

}