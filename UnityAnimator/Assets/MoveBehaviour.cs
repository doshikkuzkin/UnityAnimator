using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : StateMachineBehaviour
{
    private float time = 0;
    private float scaleTime = 2f;
    private readonly int IsScaling = Animator.StringToHash("isScaling");
    private bool scaling;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        scaling = false;
        time = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!scaling)
        {
            time += Time.deltaTime;
            if (time >= scaleTime)
            {
                scaling = true;
                animator.SetBool(IsScaling, scaling);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(IsScaling, false);
    }
}
