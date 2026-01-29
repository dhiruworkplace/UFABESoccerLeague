using Assets.RobustFSM.Mono;
using Assets.UFABESoccerLeague.Scripts.Managers;
using Assets.UFABESoccerLeague.Scripts.States.Managers.MatchManagerMainStates.Init.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Managers.MatchManagerMainStates.MatchOn.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Managers.MatchManagerMainStates.MatchOver.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Managers.MatchManagerMainState.WaitState.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Managers.MatchManagerMainState.MatchPaused.MainState;

namespace Assets.UFABESoccerLeague.Scripts.StateMachines.Managers
{
    public class MatchManagerFSM : MonoFSM<MatchManager>
    {
        public override void AddStates()
        {
            //add the states
            AddState<InitMainState>();
            AddState<MatchOnMainState>();
            AddState<MatchOverMainState>();
            AddState<WaitMainState>();

            //set the initial state
            SetInitialState<WaitMainState>();
        }
    }
}
