using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractObjectsContainer : MonoBehaviour
{
    private static List<GameObject> allInteractObjects;

    public GameObject gameEndObjectOnlySet;

    private static GameObject gameEndObject;

    private static int i = 0;
    void Awake() {
        allInteractObjects = new List<GameObject>();
        foreach (Transform item in transform)
        {
            allInteractObjects.Add(item.gameObject);
        }
    }

    void Start() {
        gameEndObject = gameEndObjectOnlySet;
    }
    void Update()
    {
        if (i < allInteractObjects.Count)
        {
            if (!allInteractObjects[i].IsDestroyed())
            {
                if (!allInteractObjects[i].GetComponent<Outline>())
                {
                    allInteractObjects[i].AddComponent<Outline>();
                }
            }
            else
            {
                i++;
            }
        }
    }

    private static bool isNextExists() {
        return i < allInteractObjects.Count;
    }

    public static GameObject GetCurrentInteractObject() {
        if(isNextExists()) {
            return allInteractObjects[i];
        } else {
            return gameEndObject;
        }
    }
}