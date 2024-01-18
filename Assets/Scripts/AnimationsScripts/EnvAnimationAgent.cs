using UnityEngine;

public class EnvAnimationAgent : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetBool(string atrName, bool isAtrName) {
        animator.SetBool(atrName, isAtrName);
    }
    
}
