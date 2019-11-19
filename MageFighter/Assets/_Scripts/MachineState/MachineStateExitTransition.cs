using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineStateExitTransition : StateMachineBehaviour
{
    public string trigger;
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (animatorStateInfo.normalizedTime >= 1) animator.SetTrigger(trigger);
    }
}
