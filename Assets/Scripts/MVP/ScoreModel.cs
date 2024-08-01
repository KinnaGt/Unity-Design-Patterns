public class ScoreModel
{
    private int score;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public void AddPoints(int points)
    {
        score += points;
    }
}
