using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DecisionController : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private Stack<ICommand> commandHistory = new Stack<ICommand>();

    public void MakeDecision(string newText)
    {
        ICommand command = new ShowTextCommand(textComponent, newText);
        command.Execute();
        commandHistory.Push(command);
    }

    public void UndoDecision()
    {
        if (commandHistory.Count > 0)
        {
            ICommand command = commandHistory.Pop();
            command.Undo();
        }
    }
}
