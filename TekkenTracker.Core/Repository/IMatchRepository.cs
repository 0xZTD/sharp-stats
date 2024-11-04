namespace TekkenTracker.Core.Repository;

public interface IMatchRepository
{
    void AddMatch(bool isWin);
    (int Wins, int Losses) GetStats(TimeSpan period);
}

