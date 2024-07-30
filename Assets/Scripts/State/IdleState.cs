using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerState
{
    public void EnterState(PlayerStateManager player, Animator animator)
    {
        Debug.Log("Entering Idle State");
    }

    public void UpdateState(PlayerStateManager player,Animator animator)
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Saltar solo en este estado
        {
            Debug.Log("Jumping");
            player.TransitionToState(player.JumpingState);
        }
    }

    public void OnCollisionEnter2D(PlayerStateManager player, Collision2D collision)
    {
        // Manejar colisiones si es necesario
    }

    public void ExitState(PlayerStateManager player)
    {
        // Logica al salir del estado
    }
}
