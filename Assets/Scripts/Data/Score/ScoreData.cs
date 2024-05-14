using EventBus;

public class ScoreData 
{
    public int Score;
}

public interface IScoreDataManager : IService
{
    public void AddLineScore(int line);
    public void ClearScore();
}

public class ScoreDataManager : IScoreDataManager
{
    private ScoreData _scoreData = new ();

    public void ActivateService()
    {
        _scoreData.Score = 0;
    }

    public void AddLineScore(int line)
    {
        if (line > 1)
            _scoreData.Score += 10 + line * 15;
        else
            _scoreData.Score += 10;
        EventBus<ScoreChanged>.Raise(new ScoreChanged { score = _scoreData.Score });
    }

    public void ClearScore()
    {
        _scoreData.Score = 0;
        EventBus<ScoreChanged>.Raise(new ScoreChanged { score = _scoreData.Score });
    }
}

