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

    public InputActionAsset actions;

    private InputAction action;

    

    public void Awake() {
        action = actions.FindActionMap("Player").FindAction("Movement");
    }

    public void Start() {
        staminaCurrent = staminaAmount;
    }

    void Update() {
        if(action.IsPressed()) {
            Spend(Time.deltaTime);
        }
    }

    public void Spend(float deltaTime) {
        staminaCurrent = Mathf.Clamp(staminaCurrent - spendingRate * deltaTime, 0, staminaAmount);
    }

    public void Refill(float amount) {
        staminaCurrent = Mathf.Clamp(staminaCurrent + amount, 0, staminaAmount);
    }
}
