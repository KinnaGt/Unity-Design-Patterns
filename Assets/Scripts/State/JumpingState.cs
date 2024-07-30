using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : IPlayerState
{
    public void EnterState(PlayerStateManager player,Animator animator)
    {
        animator.SetTrigger("Jump");
    }

    public void UpdateState(PlayerStateManager player, Animator animator)
    {
        // Logica del salto doble salto etc, como aca lo simulo todo con animaciones simplemente marco el fin de la animacion
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            player.TransitionToState(player.FallingState);
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
