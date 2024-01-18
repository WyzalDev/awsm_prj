using UnityEngine;

public class CharacterFootStepsController : MonoBehaviour
{
    private Character character;

    void Start() {
        character = transform.parent.GetComponent<Character>();
    }

    public void FootStep() {
        if(character.isMoving()) {
            if(EnvironmentState.getInstance() >= 0) {
                AudioManager.instance.PlaySfx("FootStepSummer");
            } else {
                AudioManager.instance.PlaySfx("FootStepWinter");
            }
        }
    }
}
