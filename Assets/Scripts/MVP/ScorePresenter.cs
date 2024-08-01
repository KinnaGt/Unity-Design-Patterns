public class ScorePresenter
{
    private ScoreModel model;
    private IScoreView view;

    public ScorePresenter(ScoreModel model, IScoreView view)
    {
        this.model = model;
        this.view = view;
        UpdateView();
    }

    public void AddPoints(int points)
    {
        model.AddPoints(points);
        UpdateView();
    }

    private void UpdateView()
    {
        view.UpdateScoreDisplay(model.Score);
    }
}
