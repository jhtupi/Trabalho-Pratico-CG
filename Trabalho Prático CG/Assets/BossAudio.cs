using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudio : StateMachineBehaviour
{
    private AudioSource voz1, voz2, voz3;
    int flag;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //flag = Random.Range(1, 3);
        flag = 1;
        if(flag == 1)
        {
            voz1 = GameObject.Find("Audio1").GetComponent<AudioSource>();
            voz1.Play();
        }
        else if(flag == 2)
        {
            voz2 = GameObject.Find("Audio2").GetComponent<AudioSource>();
            voz2.Play();
        }
        else if (flag == 2)
        {
            voz3 = GameObject.Find("Audio3").GetComponent<AudioSource>();
            voz3.Play();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
