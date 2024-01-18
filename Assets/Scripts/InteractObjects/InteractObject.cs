using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{

    [SerializeField]
    private Stamina stamina;
    
    [Header("Settings")]
    [SerializeField]
    private List<CardInfo> cardInfos;

    [SerializeField]
    private float staminaRestored;

    public void OnInteract() {
        if(cardInfos.Count != 0) {
            CardContainer.AddCardsWithInfo(cardInfos);
            stamina.Refill(staminaRestored);
        }
    }
}
