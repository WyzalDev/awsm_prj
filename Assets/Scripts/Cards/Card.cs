using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    private float temperature;

    private TMP_Text useTextTMP;

    
    private TMP_Text descriptionTextTMP;
    private bool isLowChoise;

    void Awake() {
        useTextTMP = transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        descriptionTextTMP =transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
    }

    public void Init(CardInfo info) {
        temperature = info.Temperature;
        useTextTMP.text = info.UseText;
        descriptionTextTMP.text = info.DescriptionText;
        isLowChoise = temperature < 0;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if(isLowChoise) {
            AudioManager.instance.PlaySfx("ChooseCardWithLow");
        } else {
            AudioManager.instance.PlaySfx("ChooseCardWithHigh");
        }
        EnvironmentState.ChangeTemperature(temperature);
        CardContainer.ActionOnChoise();
    }
}
