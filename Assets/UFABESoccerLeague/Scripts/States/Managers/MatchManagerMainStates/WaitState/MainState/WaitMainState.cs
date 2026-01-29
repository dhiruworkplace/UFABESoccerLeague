using Assets.UFABESoccerLeague.Scripts.Managers;
using Assets.UFABESoccerLeague.Scripts.StateMachines.Managers;
using RobustFSM.Base;
using Assets.UFABESoccerLeague.Scripts.States.Managers.MatchManagerMainStates.Init.MainState;
using UnityEngine;

namespace Assets.UFABESoccerLeague_.Scripts.States.Managers.MatchManagerMainState.WaitState.MainState
{
    public class WaitMainState : BState
    {
        public override void Enter()
        {
            base.Enter();

            // register to the on initialize event
            Owner.OnInitialize += GoToInitMainState;
        }

        public override void Exit()
        {
            base.Exit();

            // deregister to the event
            Owner.OnInitialize -= GoToInitMainState;
        }

        public MatchManager Owner
        {
            get
            {
                return ((MatchManagerFSM)SuperMachine).Owner;
            }
        }

        void GoToInitMainState()
        {
            Machine.ChangeState<InitMainState>();
        }
    }
}
