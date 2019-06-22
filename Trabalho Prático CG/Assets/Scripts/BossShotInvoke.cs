using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotInvoke : StateMachineBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    private int flag;
    public int flagTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        shotSpawn = GameObject.Find("BossShotSpawn").GetComponent<Transform>();
        flag = 1;
        //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (flag == flagTime)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            flag = 0;
        } else
        {
            flag = flag + 1;
        }
        

    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }

    

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
