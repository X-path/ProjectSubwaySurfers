using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MonoBehaviour, IState
{
    public void EnterState(Player player)
    {
        player.animator.SetBool("Jump", true);
        player.HandleJump();
    }

    public void ExitState(Player player)
    {
        player.animator.SetBool("Jump", false);
    }

    public void UpdateState(Player player)
    {
        if (player.IsGrounded() && player.IsJumping())
        {
            player.isJumping = false;
            player.ChangeState(new RunState());
        }



    }


}
