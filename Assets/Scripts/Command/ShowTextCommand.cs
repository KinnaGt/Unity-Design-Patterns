using TMPro;
using UnityEngine;

public class ShowTextCommand : ICommand
{
    private TextMeshProUGUI textComponent;
    private string newText;
    private string previousText;

    public ShowTextCommand(TextMeshProUGUI textComponent, string newText)
    {
        this.textComponent = textComponent;
        this.newText = newText;
        this.previousText = textComponent.text;
    }

    public void Execute()
    {
        textComponent.text = newText;
    }

    public void Undo()
    {
        textComponent.text = previousText;
    }
}
