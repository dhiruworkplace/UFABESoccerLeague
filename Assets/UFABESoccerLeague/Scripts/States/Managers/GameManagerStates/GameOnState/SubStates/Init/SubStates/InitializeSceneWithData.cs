using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.Managers;
using Assets.UFABESoccerLeague_.Scripts.Data.Dtos.Entities;
using Assets.UFABESoccerLeague_.Scripts.Data.Dtos.InGame.Entities;
using Assets.UFABESoccerLeague_.Scripts.Data.Dtos.Storage.MatchDifficulties;
using Assets.UFABESoccerLeague_.Scripts.Managers;
using Assets.UFABESoccerLeague_.Scripts.StateMachines.Managers;
using Assets.UFABESoccerLeague_.Scripts.Tactics;
using RobustFSM.Base;

namespace Assets.UFABESoccerLeague_.Scripts.States.Managers.GameManagerStates.GameOnState.SubStates.Init.SubStates
{
    public class InitializeSceneWithData : BState
    {
        public override void Enter()
        {
            base.Enter();

            // get team parameters
            MatchDifficultyTeamParam cpuMatchDifficultyParams = Owner.GetMatchDifficultyTeamParam(false, Owner.DefaultSettings.MatchSettings.MatchDifficulty);
            MatchDifficultyTeamParam userMatchDifficultyParams = Owner.GetMatchDifficultyTeamParam(true, Owner.DefaultSettings.MatchSettings.MatchDifficulty);

            // init the cpu team data
            TeamDto cpuTeamDto = Owner.CpuTeamMatchDayTeam;
            AttackTactic cpuTeamAttackTactic = Owner.GetTeamAttackTactic(cpuTeamDto.AttackType);
            DefendTactic cpuTeamDefenceTactic = Owner.GetTeamDefenceTactic(cpuTeamDto.DefenceType);
            Formation cpuFormation = FormationManager.Instance.GetFormation(cpuTeamDto.FormationType);
            KitDto cpuTeamKitDto = GetTeamKit(Owner.SelectedCpuTeamKitId, cpuTeamDto);
            InGameTeamDto cpuTeamData = new InGameTeamDto(cpuTeamAttackTactic, cpuTeamDefenceTactic, cpuFormation, cpuTeamKitDto, cpuTeamDto);

            // init the user team data
            TeamDto userTeamDto = Owner.UserTeamMatchDayTeam;
            AttackTactic userTeamAttackTactic = Owner.GetTeamAttackTactic(userTeamDto.AttackType);
            DefendTactic userTeamDefenceTactic = Owner.GetTeamDefenceTactic(userTeamDto.DefenceType);
            Formation userFormation = FormationManager.Instance.GetFormation(userTeamDto.FormationType);
            KitDto userTeamKitDto = GetTeamKit(Owner.SelectedUserTeamKitId, userTeamDto);
            InGameTeamDto userTeamData = new InGameTeamDto(userTeamAttackTactic, userTeamDefenceTactic, userFormation, userTeamKitDto, userTeamDto);

            // initialize the match manager
            MatchManager.Instance.Init(cpuMatchDifficultyParams,
                                    userMatchDifficultyParams,
                                    Owner.DefaultSettings.MatchSettings,
                                    cpuTeamData,
                                    userTeamData);

            // got wait for scene initialization
            Machine.ChangeState<WaitForSceneToInitialize>();
        }

        private GameManager Owner
        {
            get
            {
                return ((GameManagerFSM)SuperMachine).Owner;
            }
        }

        private KitDto GetTeamKit(int kitId, TeamDto teamDto)
        {
            return teamDto.Kits[kitId];
        }
    }
}
