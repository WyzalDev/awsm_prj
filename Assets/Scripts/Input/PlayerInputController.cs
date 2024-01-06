using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    //don't change it in ANY CLASSES
    public InputActionAsset actionsDontUseInClasses;


    public static InputActionAsset Actions;

    void Awake() {
        Actions = actionsDontUseInClasses;
    }

    public static void ToPlayerControls() {
        Actions.FindActionMap("UI").Disable();
        Actions.FindActionMap("Player").Enable();
    }

        public static void ToUIControls() {
        Actions.FindActionMap("Player").Disable();
        Actions.FindActionMap("UI").Enable();
    }

}
