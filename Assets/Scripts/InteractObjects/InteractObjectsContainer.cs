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

    void Start() {
        allInteractObjects = new List<GameObject>();
        foreach (Transform item in transform)
        {
            allInteractObjects.Add(item.gameObject);
        }
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

    public static bool isEmpty() {
        return !isNextExists();
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

    public static void OnSceneChange() {
        if(isNextExists()) {
            Destroy(GetCurrentInteractObject().GetComponent<Outline>());
            for(int j = i; i < allInteractObjects.Count; i++) {
                Destroy(allInteractObjects[j]);
            }
        }
        i = 0;
        allInteractObjects.Clear();
    }
}