using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputController : MonoBehaviour
{
    //don't change it in ANY CLASSES
    public InputActionAsset actionsDontUseInClasses;


    public static InputActionAsset Actions;

    void Awake() {
        SceneManager.sceneLoaded += UpdateInputAction;
        Actions = actionsDontUseInClasses;
    }

    void Start() {
        actionsDontUseInClasses.FindActionMap("Player").Enable();
    }

    public void UpdateInputAction(Scene scene, LoadSceneMode mode) {
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
