using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public int score;
}

[System.Serializable]
public class LeaderboardData
{
    public List<ScoreEntry> scores = new List<ScoreEntry>();
}
public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager instance;

    public LeaderboardData leaderboard = new LeaderboardData();
    private string savePath;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        savePath = Application.persistentDataPath + "/leaderboard.json";
        LoadLeaderboard();
    }

    public void AddScore(string playerName, int score)
    {
        leaderboard.scores.Add(new ScoreEntry
        {
            playerName = playerName,
            score = score
        });

        leaderboard.scores = leaderboard.scores
            .OrderByDescending(s => s.score)
            .Take(10)  // Top 5 aja
            .ToList();

        SaveLeaderboard();
    }

    public void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(leaderboard, true);
        File.WriteAllText(savePath, json);
    }

    public void LoadLeaderboard()
    {
        if (!File.Exists(savePath)) return;

        string json = File.ReadAllText(savePath);
        leaderboard = JsonUtility.FromJson<LeaderboardData>(json);
    }
}
