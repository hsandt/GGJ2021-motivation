using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationPoseBehaviour : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // When transitioning from one activity to another, OnStatEnter is called on the new pose state
    // then OnStateExit is called on the old pose state. This means that to detect the end of the transition
    // and that we can safely revert materials to opaque, we should use OnStateExit.
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ActivityManager.Instance.OnActivityTransitionEnd();
    }
}
