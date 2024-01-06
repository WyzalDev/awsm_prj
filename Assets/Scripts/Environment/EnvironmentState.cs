using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentState
{
    public static float temperature = 0f;

    public const int multiplicity = 10;

    private static EnvStateEnum stateInstance = EnvStateEnum.Normal;

    public static void ChangeTemperature(float changeAmount) {
        temperature += changeAmount;
        ChangeState();
    }

    private static void ChangeState() {
        //нужно чтобы состояния были кратными какому-то множителю от 5 до 10
        switch(Math.Floor(Math.Clamp(temperature/ multiplicity, -3, 3))) {
            case 3: {
                stateInstance = EnvStateEnum.Overheating;
                GameSceneManager.ChangeOnOverheatingScene();
                break;
            }
            case 2: {
                stateInstance = EnvStateEnum.TooHigh;
                break;
            }
            case 1: {
                stateInstance = EnvStateEnum.High;
                break;
            }
            case 0: {
                stateInstance = EnvStateEnum.Normal;
                break;
            }
            case -1: {
                stateInstance = EnvStateEnum.Low;
                break;
            }
            case -2: {
                stateInstance = EnvStateEnum.TooLow;
                break;
            }
            case -3: {
                stateInstance = EnvStateEnum.Overcooling;
                GameSceneManager.ChangeOnOverCoolingScene();
                break;
            }
        }
    }

    public static EnvStateEnum getInstance() {
        return stateInstance;
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