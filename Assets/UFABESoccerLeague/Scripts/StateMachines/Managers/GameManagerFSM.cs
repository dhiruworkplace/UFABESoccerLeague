using RobustFSM.Base;
using Assets.UFABESoccerLeague_.Scripts.States.Managers.GameManagerStates.Init.MainState;
using Assets.RobustFSM.Mono;
using Assets.UFABESoccerLeague.Scripts.Managers;
using Assets.UFABESoccerLeague_.Scripts.States.Managers.GameManagerStates.HomeState.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Managers.GameManagerStates.ExitState.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Managers.GameManagerStates.SettingsState.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Managers.GameManagerStates.PrepareForMatchState.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Managers.GameManagerStates.GameOnState.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Managers.GameManagerStates.TrophyState.MainState;

namespace Assets.UFABESoccerLeague_.Scripts.StateMachines.Managers
{
    public class GameManagerFSM : MonoFSM<GameManager>
    {
        public override void AddStates()
        {
            base.AddStates();

            // add states
            AddState<ExitMainState>();
            AddState<GameOnMainState>();
            AddState<HomeMainState>();
            AddState<TrophyMainState>();
            AddState<InitMainState>();
            AddState<PrepareForMatchMainState>();
            AddState<SettingsMainState>();

            // set initial state
            SetInitialState<InitMainState>();
        }
    }
}
