using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField]
    public List<CardInfo> cardInfos;

    public void OnInteract() {
        if(cardInfos.Count != 0) {
            CardContainer.AddCardsWithInfo(cardInfos);
        }
    }
}
