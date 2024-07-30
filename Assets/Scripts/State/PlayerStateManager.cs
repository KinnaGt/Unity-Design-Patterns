using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Explicacion
Se utilizan los states declarados, los mismos solo funcionan para pasar entre las distintas animaciones
le pasamos este objeto PlayerStateManager(que es lo comunmente utilizado por los states)
y en mi caso el animator por que es lo que utilizamos para simular las animaciones
Aclaracion: Este codigo es a modo didactico del patron State, no se recomienda hacerlo de esta forma en un juego real
*/
public class PlayerStateManager : MonoBehaviour
{
    public IPlayerState CurrentState { get; private set; }
    public IdleState IdleState = new IdleState();
    public JumpingState JumpingState = new JumpingState();
    public FallingState FallingState = new FallingState();

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        CurrentState = IdleState;
        CurrentState.EnterState(this, animator);
    }

    void Update()
    {
        CurrentState.UpdateState(this, animator);
    }

    public void TransitionToState(IPlayerState state)
    {
        CurrentState.ExitState(this);
        CurrentState = state;
        CurrentState.EnterState(this, animator);
    }
}
