using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MonoBehaviour, IState
{
    public void EnterState(Player player)
    {
        player.animator.SetBool("Run", true);
    }

    public void ExitState(Player player)
    {
        player.animator.SetBool("Run", false);
    }

    public void UpdateState(Player player)
    {
        /*if (UIManager.instance.GState == GameState.Fail)
        {
            player.ChangeState(new IdleState());
        }
        */
        if (player.IsGrounded() && player.IsJumping() && !player.IsRolling())
        {
            player.ChangeState(new JumpState());
        }
        else if (player.IsGrounded() && !player.IsJumping() && player.IsRolling())
        {
            player.ChangeState(new RollState());
        }

    }


}
