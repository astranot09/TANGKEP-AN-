using TMPro;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    //public LeaderboardManager manager;
    public TMP_Text leaderboardText;

    private void OnEnable()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        leaderboardText.text = "";

        int rank = 1;
        foreach (var entry in LeaderboardManager.instance.leaderboard.scores)
        {
            leaderboardText.text +=
                $"{rank}. {entry.playerName} - {entry.score}\n";
            rank++;
        }
    }
}