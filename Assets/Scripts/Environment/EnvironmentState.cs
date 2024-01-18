using System;

//singleton
public class EnvironmentState
{
    public static float temperature = 0f;

    public const int multiplicity = 10;

    private static EnvStateEnum instance = EnvStateEnum.Normal;

    public static EnvStateEnum lastState = EnvStateEnum.Normal;

    public static bool isGame = true;

    public static void ChangeTemperature(float changeAmount) {
        temperature += changeAmount;
        ChangeState();
    }

    private static void ChangeState() {
        lastState = instance;
        //нужно чтобы состояния были кратными какому-то множителю от 5 до 10
        switch(SwitchCaseCondition()) {
            case 3: {
                instance = EnvStateEnum.Overheating;
                GameSceneManager.ChangeOnOverheatingScene();
                break;
            }
            case 2: {
                instance = EnvStateEnum.TooHigh;
                break;
            }
            case 1: {
                instance = EnvStateEnum.High;
                break;
            }
            case 0: {
                if(SwitchCaseCondition() != (int) instance) {
                    AudioManager.instance.PlaySfx("ChangeWeather");
                }
                instance = EnvStateEnum.Normal;
                break;
            }
            case -1: {
                if(SwitchCaseCondition() != (int) instance) {
                    AudioManager.instance.PlaySfx("ChangeWeather");
                }
                instance = EnvStateEnum.Low;
                break;
            }
            case -2: {
                instance = EnvStateEnum.TooLow;
                break;
            }
            case -3: {
                instance = EnvStateEnum.Overcooling;
                GameSceneManager.ChangeOnOverCoolingScene();
                break;
            }
        }
    }

    public static void StopGame() {
        isGame = false;
        dropToDefault();
    }

    private static void dropToDefault() {
        temperature = 0;
        instance = EnvStateEnum.Normal;
        lastState = EnvStateEnum.Normal;
    }

    public static void StartGame() {
        isGame = true;
    }

    private static double SwitchCaseCondition() {
        return Math.Floor(Math.Clamp(temperature/ multiplicity, -3, 3));
    }

    public static EnvStateEnum getInstance() {
        return instance;
    }

}

public enum EnvStateEnum {
    Overheating = 3 * EnvironmentState.multiplicity,
    TooHigh = 2 * EnvironmentState.multiplicity,
    High = 1 * EnvironmentState.multiplicity,
    Normal = 0 * EnvironmentState.multiplicity,
    Low = -1 * EnvironmentState.multiplicity,
    TooLow = -2 * EnvironmentState.multiplicity,
    Overcooling = -3 * EnvironmentState.multiplicity
}