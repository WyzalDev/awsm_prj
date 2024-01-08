using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Slider staminaSlider;

    public Stamina stamina;

    void Start() {
        staminaSlider = GetComponent<Slider>();
    }

    void Update() {
        if(staminaSlider.value!= stamina.staminaCurrent) {
            staminaSlider.value = stamina.staminaCurrent;
        }
    }
    
}
