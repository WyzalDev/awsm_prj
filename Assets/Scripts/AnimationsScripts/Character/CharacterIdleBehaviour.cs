using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleBehaviour : StateMachineBehaviour
{
    [SerializeField]
    private float TimeUntilBored;

    [SerializeField]
    private int NumberOfBoredAnimations;

    private bool isBored;

    private float IdleTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       ResetIdle(animator);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(!isBored) {
            IdleTime += Time.deltaTime;
            if(IdleTime > TimeUntilBored && stateInfo.normalizedTime % 1 < 1) {
                isBored = true;
                int currentBoredAnimation = Random.Range(1, NumberOfBoredAnimations + 1);

                animator.SetFloat("BoredAnimation", currentBoredAnimation);
            }
       } else if (stateInfo.normalizedTime % 1 > 0.98) {
                ResetIdle(animator);
       }
    }

    private void ResetIdle(Animator animator) {
        isBored = false;
        IdleTime = 0;

        animator.SetFloat("BoredAnimation", 0);
    }
}
