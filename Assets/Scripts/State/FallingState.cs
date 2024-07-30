using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : IPlayerState
{
    public void EnterState(PlayerStateManager player, Animator animator)
    {
        Debug.Log("Entering Falling State");
    }

    public void UpdateState(PlayerStateManager player, Animator animator)
    {
        // Logica de la caida
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            player.TransitionToState(player.IdleState);
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
