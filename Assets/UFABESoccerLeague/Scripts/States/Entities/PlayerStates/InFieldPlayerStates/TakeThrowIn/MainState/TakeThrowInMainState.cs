using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.StateMachines.Entities;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.GoToHome.MainState;
using Assets.UFABESoccerLeague.Scripts.Utilities;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.TakeThrowIn.SubStates;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.Team.ThrowIn.SubStates;
using Assets.UFABESoccerLeague_.Scripts.Utilities.Enums;
using RobustFSM.Base;
using UnityEngine;

namespace Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.TakeThrowIn.MainState
{
    public class TakeThrowInMainState : BHState
    {
        float _cachedMaxWonderDistance;

        public override void AddStates()
        {
            base.AddStates();

            // add states
            AddState<AutomaticTakeThrow>();
            AddState<ManualTakeThrow>();
            AddState<PrepareToTakeThrowIn>();

            // set initial state
            SetInitialState<PrepareToTakeThrowIn>();
        }

        public override void Enter()
        {
            base.Enter();

            _cachedMaxWonderDistance = Owner.DistanceMaxWonder;
        }

        public override void Exit()
        {
            base.Exit();

            Owner.DistanceMaxWonder = _cachedMaxWonderDistance;
        }

        public Player Owner
        {
            get
            {
                return ((InFieldPlayerFSM)SuperMachine).Owner;
            }
        }
    }
}
