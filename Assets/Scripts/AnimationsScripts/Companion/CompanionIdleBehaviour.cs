using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CompanionIdleBehaviour : StateMachineBehaviour
{
    [SerializeField]
    private int numberOfAnimations;

    [SerializeField]
    private string nameOfAnimatorParameter;

    [SerializeField]
    private float pauseAfterChange;

    private float currentPause = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(currentPause == 0) {
            currentPause = pauseAfterChange;
            ChangeIdleAnimation(animator);
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentPause = Mathf.Clamp(currentPause - Time.deltaTime, 0, pauseAfterChange);
    }

    private void ChangeIdleAnimation(Animator animator) {
        float currentAnimation;
        if(nameOfAnimatorParameter == "IdleAnimation") {
            switch (animator.GetFloat(nameOfAnimatorParameter)) {
                case 0 : {
                    currentAnimation = 1;
                    break;
                }
                default : {
                    currentAnimation = 0;
                    break;
                }
            }
            animator.SetFloat(nameOfAnimatorParameter, currentAnimation);
        }
    }

}
