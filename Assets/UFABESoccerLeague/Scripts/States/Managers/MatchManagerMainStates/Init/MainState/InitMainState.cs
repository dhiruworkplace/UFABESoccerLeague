using Assets.UFABESoccerLeague.Scripts.Managers;
using Assets.UFABESoccerLeague.Scripts.StateMachines.Managers;
using Assets.UFABESoccerLeague.Scripts.States.Managers.MatchManagerMainStates.Init.SubStates;
using RobustFSM.Base;

namespace Assets.UFABESoccerLeague.Scripts.States.Managers.MatchManagerMainStates.Init.MainState
{
    public class InitMainState : BHState
    {
        public override void AddStates()
        {
            base.AddStates();

            //add states
            AddState<Initialize>();
            AddState<WaitForMatchOnInstruction>();

            //set initial state
            SetInitialState<Initialize>();
        }

        public MatchManager Owner
        {
            get
            {
                return ((MatchManagerFSM)SuperMachine).Owner;
            }
        }
    }
}
