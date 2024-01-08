using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static string overheatingScene = "OverheatedAnimation";

    public static string overCoolingScene = "OvercoolingAnimation";

    public static string outOfStaminaScene = "OutOfStaminaAnimation";

    public static string summerWinScene = "SummerWinAnimation";

    public static string winterWinScene = "WinterWinAnimation";

    public static void ChangeOnOverheatingScene() {
        AudioManager.instance.PlayMusic("GameOver");
        LoadScene(overheatingScene);
    }

    public static void ChangeOnOverCoolingScene() {
        AudioManager.instance.PlayMusic("GameOver");
        LoadScene(overCoolingScene);
    }

    public static void ChangeOnOutOfStaminaScene() {
        AudioManager.instance.PlayMusic("GameOver");
        LoadScene(outOfStaminaScene);
    }

    public static void ChangeOnSummerWinScene() {
        AudioManager.instance.PlayMusic("SummerGameEnd");
        LoadScene(summerWinScene);
    }

    public static void ChangeOnWinterWinScene() {
        AudioManager.instance.PlayMusic("WinterGameEnd");
        LoadScene(winterWinScene);
    }

    private static void LoadScene(string sceneName) {
        InteractObjectsContainer.OnSceneChange();
        EnvironmentState.StopGame();
        SceneManager.LoadScene(sceneName);
    }

}
