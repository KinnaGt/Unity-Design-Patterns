using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    void EnterState(PlayerStateManager player,Animator animator);
    void UpdateState(PlayerStateManager player,Animator animator);
    void OnCollisionEnter2D(PlayerStateManager player, Collision2D collision);
    void ExitState(PlayerStateManager player); 
}
