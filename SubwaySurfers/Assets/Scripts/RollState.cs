using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : MonoBehaviour, IState
{
    public void EnterState(Player player)
    {
        player.animator.SetBool("Roll", true);
    }

    public void ExitState(Player player)
    {
        player.animator.SetBool("Roll", false);
    }

    public void UpdateState(Player player)
    {
        if (player.IsGrounded() && !player.IsRolling())
        {
            player.ChangeState(new RunState());
        }
        
    }


}
