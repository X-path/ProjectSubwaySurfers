using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonoBehaviour, IState
{
    public void EnterState(Player player)
    {
        player.animator.SetBool("Idle", true);
    }
    public void ExitState(Player player)
    {
        player.animator.SetBool("Idle", false);
    }
    public void UpdateState(Player player)
    {
        if (UIManager.instance.GState == GameState.Play)
        {
           
            player.ChangeState(new RunState());
        }

    }

}
