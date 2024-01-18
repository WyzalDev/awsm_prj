using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

//needed to be a singleton (some singleton behaviour presents by this class)
public class PlayerInputController : MonoBehaviour
{
    //don't change it in ANY CLASSES
    [SerializeField]
    private InputActionAsset actions;

    public static InputActionAsset Actions;

    void Awake() {
        SceneManager.sceneLoaded += UpdateInputAction;
        Actions = actions;
    }

    void Start() {
        actions.FindActionMap("Player").Enable();
    }

    public void UpdateInputAction(Scene scene, LoadSceneMode mode) {
        Actions = actions;
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
