using Assets.FootballGameEngine_Indie.Scripts.Managers;
using Assets.FootballGameEngine_Indie_.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text title;
    public TextMeshProUGUI team1;
    public TextMeshProUGUI team2;
    public TextMeshProUGUI score;
    public TextMeshProUGUI reward;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (title.text.EndsWith("You Won"))
        {
            reward.text = "1000";
            FarmsApp.coins += 1000;
        }
        team1.text = MatchManager.Instance.AwayTeamData.ShortName;
        team2.text = MatchManager.Instance.HomeTeamData.ShortName;
        score.text = GraphicsManager.Instance.GameOnMainMenu.MatchInPlayMainMenu.MatchPlayMenu.TxtScores.text;
    }
}