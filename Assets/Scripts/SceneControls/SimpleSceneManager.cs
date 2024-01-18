using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Canvas))]
public class SimpleSceneManager : MonoBehaviour, IPointerDownHandler
{
    [Header("Settings")]
    [SerializeField]
    private string sceneName = "Game";

    [SerializeField]
    private float pauseTime = 2f;

    [SerializeField]
    private float CantSkipTime = 1.5f;

    [SerializeField]
    private bool SkipByAnyKeyOnKeyboard = true;

    [SerializeField]
    private bool SkipByMouseClick = true;

    private GameObject skipText;

    private float leftTime;

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
