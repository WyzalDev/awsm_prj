using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Canvas))]
public class SimpleSceneManager : MonoBehaviour, IPointerDownHandler
{
    public string sceneName = "Game";

    public float pauseTime = 2f;

    public float CantSkipTime = 1.5f;

    private float leftTime;

    private GameObject skipText;

    public bool SkipByAnyKeyOnKeyboard = true;

    public bool SkipByMouseClick = true;

    void Start()
    {
        skipText = transform.GetChild(0).gameObject;
        leftTime = pauseTime + CantSkipTime;
    }

    void Update()
    {
        leftTime = Mathf.Clamp(leftTime - Time.deltaTime, 0, pauseTime + CantSkipTime);
        if (leftTime <= pauseTime)
        {
            if(!skipText.activeSelf &&  SkipByAnyKeyOnKeyboard) {
                skipText.SetActive(true);
            }
            if (leftTime == 0)
            {
                ChangeScene();
            }
            if (Keyboard.current.anyKey.isPressed && SkipByAnyKeyOnKeyboard)
            {
                ChangeScene();
            }
        }
    }

    public void ChangeScene()
    {
        AudioManager.instance.PlayMusicWithoutChange("SummerWalk");;
        EnvironmentState.StartGame();
        SceneManager.LoadScene(sceneName);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ChangeScene();
    }
}
