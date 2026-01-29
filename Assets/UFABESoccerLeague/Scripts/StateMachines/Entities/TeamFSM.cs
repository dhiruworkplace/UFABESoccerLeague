using Assets.RobustFSM.Mono;
using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.States.Entities.TeamStates.Attack.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.TeamStates.Defend.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.TeamStates.Init.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.TeamStates.KickOff.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.TeamStates.Wait.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.Team.ThrowIn.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.Team.GoalKick.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.Team.CornerKick.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.Team.CounterKick.MainState;

namespace Assets.UFABESoccerLeague.Scripts.StateMachines.Entities
{
    public class TeamFSM : MonoFSM<Team>
    {
        public override void AddStates()
        {
            //set the update frequency
            SetUpdateFrequency(Owner.AiUpdateFrequency);

            //add the states
            AddState<AttackMainState>();
            AddState<CornerKickMainState>();
            AddState<CounterKickMainState>();
            AddState<GoalKickMainState>();
            AddState<InitMainState>();
            AddState<DefendMainState>();
            AddState<KickOffMainState>();
            AddState<ThrowInMainState>();
            AddState<WaitMainState>();

            //set the initial state
            SetInitialState<InitMainState>();
        }
    }
}
