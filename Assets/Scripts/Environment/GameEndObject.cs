using Unity.VisualScripting;
using UnityEngine;

public class GameEndObject : EnvironmentObject
{
    [SerializeField]
    private Character character;

    [Header("Settings")]
    [SerializeField]
    private float characterDistanceToEnd;

    void Start()
    {
        winterAgent = this.transform.GetChild(0).GetComponent<EnvAnimationAgent>();
        summerAgent = this.transform.GetChild(1).GetComponent<EnvAnimationAgent>();
        firstChange = true;
    }
    // Update is called once per frame
    void Update()
    {
        SwitchEnvironmentState();
        if(!character.IsDestroyed() && IsCharacterNear() && InteractObjectsContainer.isEmpty()) {
            switch(EnvironmentState.getInstance() < 0) {
                case true : {
                    GameSceneManager.ChangeOnWinterWinScene();
                    break;
                }
                default : {
                    GameSceneManager.ChangeOnSummerWinScene();
                    break;
                }
            }
        }
    }

    public bool IsCharacterNear() {
        float distanceToCharacter = (character.transform.position - transform.position).magnitude;
        return characterDistanceToEnd > distanceToCharacter;
    }

}
