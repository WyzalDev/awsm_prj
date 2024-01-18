using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField]
    private Stamina stamina;

    private Slider staminaSlider;

    void Start() {
        staminaSlider = GetComponent<Slider>();
    }

    void Update() {
        if(staminaSlider.value!= stamina.Current) {
            staminaSlider.value = stamina.Current;
        }
    }
    
}
