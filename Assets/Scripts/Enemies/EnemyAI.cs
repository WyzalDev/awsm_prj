using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent meshAgent;

    public Transform character;

    public LayerMask groundMask, characterMask;

    public Stamina stamina;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    public float damage;
    bool alreadyAttacked;

    //Animator
    private Animator animator;

    private const string isMovingParam = "IsMooving";
    private const string attackTriggerParam = "Attack";


    //States
    public float sightRange, attackRange;
    public bool characterInSightRange, characterInAttackRange;

    void Awake() {
        meshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        //Check for sight and attack range
        characterInSightRange = Physics.CheckSphere(transform.position, sightRange, characterMask);
        characterInAttackRange =  Physics.CheckSphere(transform.position, attackRange, characterMask);

        if(!characterInSightRange && !characterInAttackRange) Patroling();
        if(characterInSightRange && !characterInAttackRange) ChaseCharacter();
        if(characterInSightRange && characterInAttackRange) AttackCharacter();
        
        animator.SetBool(isMovingParam, meshAgent.velocity.magnitude > 0.01f);
    }

    private void Patroling() {
        if(!walkPointSet) {
            SearchWalkPoint();
        } else {
            meshAgent.SetDestination(walkPoint);
        }

        Vector3 distanceWalkPoint = transform.position - walkPoint;

        //WalkPoint reached
        if(distanceWalkPoint.magnitude < 1f) {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint() {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        //if ground under us, then walkPointSet = true
        walkPointSet = Physics.Raycast(walkPoint, -transform.up, 2f, groundMask);
    }
    private void AttackCharacter() {
        meshAgent.SetDestination(transform.position);

        transform.LookAt(character);

        if(!alreadyAttacked) {
            //Attack logics
            animator.SetTrigger(attackTriggerParam);
            stamina.Spend(damage);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ChaseCharacter() {
        meshAgent.SetDestination(character.position);
    }

    private void ResetAttack() {
        alreadyAttacked = false;
    }

}
