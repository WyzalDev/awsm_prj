using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class Stamina : MonoBehaviour
{
    public float staminaCurrent;

    public float staminaAmount = 100f;

    public float spendingRate = 1f;

    private InputActionAsset actions;

    private InputAction action;


    public void Start() {
        staminaCurrent = staminaAmount;
        actions = PlayerInputController.Actions;
        action = actions.FindActionMap("Player").FindAction("Movement");
    
    }

    void Update() {
        if(action.IsPressed()) {
            Spend(Time.deltaTime);
        }
        if(staminaCurrent == 0) {
            GameSceneManager.ChangeOnOutOfStaminaScene();
        }
    }

    public void Spend(float deltaTime) {
        staminaCurrent = Mathf.Clamp(staminaCurrent - spendingRate * deltaTime, 0, staminaAmount);
    }

    public void Refill(float amount) {
        staminaCurrent = Mathf.Clamp(staminaCurrent + amount, 0, staminaAmount);
    }
}
