using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndObject : EnvironmentObject
{
    public Character character;

    public float characterDistanceToEnd;

    // Update is called once per frame
    void Update()
    {
        SwitchEnvironmentState();
        if(IsCharacterNear() && InteractObjectsContainer.isEmpty()) {
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
