using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionStepsController : MonoBehaviour
{   
    private Companion companion;

    private AudioSource companionSfxSource;

    void Start() {
        companion = transform.parent.GetComponent<Companion>();
        companionSfxSource = companion.sfxSource;
    }

    public void FootStep() {
        if(companion.getState() != CompanionState.Idle || companion.isMoving()) {
            if(EnvironmentState.getInstance() >= 0) {
                AudioManager.instance.PlaySfXForCompanion("FootStepSummerFox", companionSfxSource);
            } else {
                AudioManager.instance.PlaySfXForCompanion("FootStepWinterFox", companionSfxSource);
            }
        }
    }
}
