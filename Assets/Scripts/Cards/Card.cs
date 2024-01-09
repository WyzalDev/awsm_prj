using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    public float temperature;

    public String useText;

    public String descriptionText;

    private TMP_Text useTextTMP;

    
    private TMP_Text descriptionTextTMP;
    public bool isLowChoise;

    void Awake() {
        useTextTMP = transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        descriptionTextTMP =transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
    }

    public void Init(CardInfo info) {
        temperature = info.Temperature;
        useText = info.UseText;
        descriptionText = info.DescriptionText;
        useTextTMP.text = info.UseText;
        descriptionTextTMP.text = info.DescriptionText;
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
