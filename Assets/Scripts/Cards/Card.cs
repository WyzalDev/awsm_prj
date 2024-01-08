using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    public float temperature;

    public String text;

    public bool isLowChoise;

    public void Init(CardInfo info) {
        temperature = info.Temperature;
        text = info.Text;
        isLowChoise = temperature < 0;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if(isLowChoise) {
            AudioManager.instance.PlaySFX("ChooseCardWithLow");
        } else {
            AudioManager.instance.PlaySFX("ChooseCardWithHigh");
        }
        EnvironmentState.ChangeTemperature(temperature);
        CardContainer.ActionOnChoise();
    }
}
