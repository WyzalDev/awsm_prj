using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private static string overheatingScene = "OverheatedAnimation";

    private static string overCoolingScene = "OvercoolingAnimation";

    private static string outOfStaminaScene = "OutOfStaminaAnimation";

    private static string summerWinScene = "SummerWinAnimation";

    private static string winterWinScene = "WinterWinAnimation";

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
