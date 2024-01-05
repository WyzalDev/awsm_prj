using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractObjectsAndNavigator : MonoBehaviour
{
    public List<GameObject> allInteractObjects;

    private int i = 0;
    void Awake() {
        allInteractObjects = new List<GameObject>();
        foreach (Transform item in transform)
        {
            allInteractObjects.Add(item.gameObject);
        }
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
}