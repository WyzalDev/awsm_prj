using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardContainer : MonoBehaviour
{
    //TODO private
    public static List<GameObject> cardContainer;

    private static GameObject cardPrefab;

    public GameObject cardPrefabOnlySet;

    private static Transform containerTransform;

    private static GameObject fade;

    public Transform menuOnlySet;

    //TODO private
    public static CardContainerState state;

    private static Transform thisClassTransform;

    void Awake() {
        cardContainer = new List<GameObject>();
        thisClassTransform = transform;
        cardPrefab = cardPrefabOnlySet;
    }

    void Start() {
        containerTransform = menuOnlySet.Find("CardsContainer");
        fade = menuOnlySet.Find("Fade").gameObject;
    }

    private static void ChangeState() {
        switch(cardContainer.Count) {
            case 0 : {
                state = CardContainerState.ListEmpty;
                break;
            }
            default : {
                AudioManager.instance.PlaySFX("FlipCard");
                state = CardContainerState.ListNotEmpty;
                break;
            }
        }
    }

    public static void AddCardsWithInfo(List<CardInfo> cardsInfo) {
        if(state == CardContainerState.ListEmpty) {
            PlayerInputController.ToUIControls();
        }
        fade.SetActive(true);
        foreach (CardInfo item in cardsInfo) {
            GameObject card = Instantiate(cardPrefab, containerTransform);
            card.AddComponent<Card>().Init(item);
            cardContainer.Add(card);
        }
        ChangeState();
    }

    public static void ActionOnChoise() {
        foreach (GameObject card in cardContainer) {
            Destroy(card);
        }
        cardContainer.Clear();
        ChangeState();
        PlayerInputController.ToPlayerControls();
        fade.SetActive(false);
    }

}

public enum CardContainerState{
    ListEmpty,
    ListNotEmpty
}
