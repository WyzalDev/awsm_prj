using UnityEngine;
using UnityEngine.UI;

public class TemperatureBar : MonoBehaviour
{
    private Slider temperatureSlider;

    private RectTransform blueBar;
    private RectTransform redBar;

    void Start() {
        temperatureSlider = transform.GetChild(0).GetComponent<Slider>();
        blueBar = transform.GetChild(0).GetChild(1).GetComponent<RectTransform>();
        redBar = transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
    }

    void Update() {
        
        float temp = EnvironmentState.temperature;
        if(temp>=0 && !redBar.gameObject.activeSelf) {
            ChangeBar();
        }

        if(temp < 0 && !blueBar.gameObject.activeSelf) {
            ChangeBar();
        }

        if(temperatureSlider.value != Mathf.Abs(temp)) {
            temperatureSlider.value = Mathf.Abs(temp);
        }

    }

    void ChangeBar() {
        if(redBar.gameObject.activeSelf) {
            blueBar.gameObject.SetActive(true);
            temperatureSlider.fillRect = blueBar.GetChild(0).GetComponent<RectTransform>();
            redBar.gameObject.SetActive(false);
            temperatureSlider.direction = Slider.Direction.RightToLeft;
        } else {
            redBar.gameObject.SetActive(true);
            temperatureSlider.fillRect = redBar.GetChild(0).GetComponent<RectTransform>();
            blueBar.gameObject.SetActive(false);
            temperatureSlider.direction = Slider.Direction.LeftToRight;
        }
    }

}
