using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public DecisionController decisionController;

    void Start()
    {
        decisionController.MakeDecision("Welcome to the game! Do you go left or right?");
    }

    public void OnLeftDecision()
    {
        decisionController.MakeDecision("You went left. You find a treasure!");
    }

    public void OnRightDecision()
    {
        decisionController.MakeDecision("You went right. You encounter a monster!");
    }

    public void OnUndoDecision()
    {
        decisionController.UndoDecision();
    }
}
