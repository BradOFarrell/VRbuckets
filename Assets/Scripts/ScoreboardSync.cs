using Normal.Realtime;
using System.Linq;
using TMPro;
using UnityEngine;


public class ScoreboardSync : RealtimeComponent<ScoreboardModel>
{
    [SerializeField]
    private TextMeshPro _scoreDisplay;
    [SerializeField]
    private TextMeshPro _bonusDisplay;



    void Awake()
    {
        // Get the TextMesh component attached to this GameObject
        _scoreDisplay = GetComponent<TextMeshPro>();

        // Set the text to a new value
        _scoreDisplay.text = "0  0";
    }

    public int GetScore(uint playerId)
    {
        if (!PlayerExistsInDict(playerId)) return 0;

        return model.players[playerId].score;
    }

    public void IncrementScore(uint playerId, bool trickshot, bool consecutive)
    {
        int totalScore = 1;
        string bonusText = "";

        if (!PlayerExistsInDict(playerId)) {
            AddPlayerToDict(playerId);
        }

        if (trickshot) {
            totalScore += 3;
            bonusText += "Trick Shot +3\n";
        }

        if (consecutive) {
            totalScore += 1;
            bonusText += "Consecutive +1";
        }

        _bonusDisplay.text = bonusText;
        model.players[playerId].score += totalScore;
    }

    private void Update()
    {
        _scoreDisplay.text = GetScore(0) + "  " + GetScore(1);
    }

    private void AddPlayerToDict(uint playerId)
    {
        UserScoreModel newUserScoreModel = new UserScoreModel();
        newUserScoreModel.score = 0;
        model.players.Add(playerId, newUserScoreModel);
    }

    private bool PlayerExistsInDict(uint playerId)
    {
        try
        {
            UserScoreModel _ = model.players[playerId];
            return true;
        }
        catch
        {
            return false;
        }
    }
}