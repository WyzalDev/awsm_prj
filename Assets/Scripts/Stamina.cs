using UnityEngine.InputSystem;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [Header("Stamina settings")]
    [SerializeField]
    private float amount = 100f;

    [SerializeField]
    private float spendingRate = 1f;

    private float current;

    public float Current {
        get {return current; }
        private set {current = value;}
    }

    private InputActionAsset actions;

    private InputAction action;


    public void Start() {
        current = amount;
        actions = PlayerInputController.Actions;
        action = actions.FindActionMap("Player").FindAction("Movement");
    
    }

    void Update() {
        if(action.IsPressed()) {
            Spend();
        }
        if(current == 0) {
            GameSceneManager.ChangeOnOutOfStaminaScene();
        }
    }

    private void Spend() {
        Spend(spendingRate * Time.deltaTime);
    }

    public void Spend(float spended) {
        current= Mathf.Clamp(current - spended, 0, amount);;
    }

    public void Refill(float amount) {
        current = Mathf.Clamp(current + amount, 0, this.amount);
    }
}
