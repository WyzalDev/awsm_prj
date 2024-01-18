using System.Collections.Generic;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    private static List<GameObject> cardContainer;

    private static GameObject cardPrefab;

    [SerializeField]
    private GameObject cardPrefabOnlySet;

    [SerializeField]
    private Transform menuOnlySet;

    private static Transform containerTransform;

    private static GameObject fade;

    private static CardContainerState state;

    void Awake() {
        cardContainer = new List<GameObject>();
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
                AudioManager.instance.PlaySfx("FlipCard");
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
