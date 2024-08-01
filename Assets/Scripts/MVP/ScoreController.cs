using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private ScorePresenter presenter;

    void Start()
    {
        ScoreModel model = new ScoreModel();
        IScoreView view = GetComponent<ScoreView>();
        presenter = new ScorePresenter(model, view);
    }

    public void AddPoints(int points)
    {
        presenter.AddPoints(points);
    }
}
