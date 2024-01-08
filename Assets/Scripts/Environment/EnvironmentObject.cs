using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObject : MonoBehaviour
{

    private bool isWinter;

    protected bool firstChange;

    protected EnvAnimationAgent summerAgent;

    protected EnvAnimationAgent winterAgent;

    void Start()
    {
        winterAgent = transform.GetChild(0).GetComponent<EnvAnimationAgent>();
        summerAgent = transform.GetChild(1).GetComponent<EnvAnimationAgent>();
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

    protected void SwitchToWinterModel() {
        isWinter = true;
        summerAgent.SetBool("IsSummer", false);
        winterAgent.SetBool("IsWinter", true);
    }

    protected void SwitchToSummerModel() {
        isWinter = false;
        winterAgent.SetBool("IsWinter", false);
        summerAgent.SetBool("IsSummer", true);
    }
}
