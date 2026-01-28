using SmartMenuManagement.Scripts;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FootballGameEngine_Indie_.Scripts.UI.Menus.GameOnMenu.SubMenus.MatchInPlayMenu.SubMenus
{
    [Serializable]
    public class MatchPlayMenu : BSubMenu
    {
        [SerializeField]
        Button _btnPauseMatch;

        [SerializeField]
        Text _txtTeam1;

        [SerializeField]
        Text _txtScores;

        [SerializeField]
        Text _txtTeam2;

        [SerializeField]
        Text _txtTime;

        [SerializeField]
        GameObject _radarRoot;

        public Text TxtScores { get => _txtScores; set => _txtScores = value; }
        public Text TxtTime { get => _txtTime; set => _txtTime = value; }
        public Button BtnPauseMatch { get => _btnPauseMatch; set => _btnPauseMatch = value; }
        public GameObject RadarRoot { get => _radarRoot; set => _radarRoot = value; }

        public void Init(bool isRadarOn, int scoresTeamAway, int scoresTeamHome, string nameAwayTeam, string nameHomeTeam, string time)
        {
            _txtScores.text = string.Format("{0}-{1}", scoresTeamAway, scoresTeamHome);
            _txtTime.text = time;
            _txtTeam1.text = nameAwayTeam;
            _txtTeam2.text = nameHomeTeam;

            _radarRoot.SetActive(isRadarOn);
        }
    }
}
