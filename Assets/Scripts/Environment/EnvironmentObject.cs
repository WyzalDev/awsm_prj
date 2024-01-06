using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObject : MonoBehaviour
{
    private GameObject WinterModel;

    private GameObject SummerModel;

    private bool isWinter;

    private bool firstChange;

    void Start()
    {
        WinterModel = transform.Find("Winter").gameObject;
        SummerModel = transform.Find("Summer").gameObject;
        firstChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchEnvironmentState();
    }

    protected void SwitchEnvironmentState() {
        switch(EnvironmentState.getInstance()) {
            case EnvStateEnum.Overheating :
            case EnvStateEnum.TooHigh :
            case EnvStateEnum.High :
            case EnvStateEnum.Normal : {
                if(isWinter || firstChange) {
                    firstChange = false;
                    SwitchToSummerModel();
                }
                break;
            }
            default : {
                if(!isWinter || firstChange) {
                    firstChange = false;
                    SwitchToWinterModel();
                }
                break;
            }
        }
    }

    void SwitchToWinterModel() {
        isWinter = true;
        SummerModel.SetActive(false);
        WinterModel.SetActive(true);
    }

    void SwitchToSummerModel() {
        isWinter = false;
        WinterModel.SetActive(false);
        SummerModel.SetActive(true);
    }
}
