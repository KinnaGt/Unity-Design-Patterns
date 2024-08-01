using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour, IScoreView
{
    public TextMeshProUGUI scoreText;

    public void UpdateScoreDisplay(int score)
    {
        scoreText.text = score.ToString();
    }
}
