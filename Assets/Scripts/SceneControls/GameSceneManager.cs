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
        LoadScene(overheatingScene);
    }

    public static void ChangeOnOverCoolingScene() {
        LoadScene(overCoolingScene);
    }

    public static void ChangeOnOutOfStaminaScene() {
        LoadScene(outOfStaminaScene);
    }

    public static void ChangeOnSummerWinScene() {
        LoadScene(summerWinScene);
    }

    public static void ChangeOnWinterWinScene() {
        LoadScene(winterWinScene);
    }

    private static void LoadScene(string sceneName) {
        InteractObjectsContainer.OnSceneChange();
        SceneManager.LoadScene(sceneName);
    }

}
