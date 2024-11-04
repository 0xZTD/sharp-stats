using System.Text.Json;
using TekkenTracker.Core.Models;

namespace TekkenTracker.Core.Repository;

public class JsonMatchRepository : IMatchRepository
{
    private readonly string _filePath;
    private List<Match> _matches;

    public JsonMatchRepository(string filePath = "matches.json")
    {
        _filePath = filePath;
        _matches = LoadMatches();
    }

    private List<Match> LoadMatches()
    {
        if (!File.Exists(_filePath)) return [];

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Match>>(json) ?? [];
    }

    public void AddMatch(bool isWin)
    {
        _matches.Add(new Match
        {
            IsWin = isWin,
            Date = DateTime.Now
        });
        SaveMatches();
    }

    private void SaveMatches()
    {
        var json = JsonSerializer.Serialize(_matches, new JsonSerializerOptions
        {
            WriteIndented = true,
        });

        File.WriteAllText(_filePath, json);
    }

    public (int Wins, int Losses) GetStats(TimeSpan period)
    {
        var offset = DateTime.Now.Date - period;
        var matches = _matches.Where(x => x.Date >= offset);


        return (Wins: matches.Count(m => m.IsWin), Losses: matches.Count(m => !m.IsWin));
    }
}