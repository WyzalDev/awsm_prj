using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    public float temperature;

    public String text;

    public void Init(CardInfo info) {
        temperature = info.Temperature;
        text = info.Text;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        EnvironmentState.ChangeTemperature(temperature);
        CardContainer.ActionOnChoise();
    }
}
