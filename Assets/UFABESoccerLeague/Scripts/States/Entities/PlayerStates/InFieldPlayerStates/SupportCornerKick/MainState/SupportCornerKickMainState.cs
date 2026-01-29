using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.StateMachines.Entities;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.GoToHome.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.ReceiveBall.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.Wait.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.SupportCornerKick.SubStates;
using RobustFSM.Base;
using System;
using UnityEngine;

namespace Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.SupportCornerKick.MainState
{
    public class SupportCornerKickMainState : BHState
    {
        public override void AddStates()
        {
            base.AddStates();

            // add the states
            AddState<FindRandomPointToAttackCornerKick>();
            AddState<SteerToAttackCornerKickPoint>();
            AddState<WaitAtAttackCornerKickPoint>();

            // set initial state
            SetInitialState<FindRandomPointToAttackCornerKick>();
        }

        public override void Enter()
        {
            base.Enter();

            //listen to variaus events
            Owner.OnInstructedToGoToHome += Instance_OnInstructedToGoToHome;
            Owner.OnInstructedToReceiveBall += Instance_OnInstructedToReceiveBall;
            Owner.OnInstructedToWait += Instance_OnWait;
        }

        public override void Exit()
        {
            base.Exit();

            // deregister from events
            Owner.OnInstructedToGoToHome -= Instance_OnInstructedToGoToHome;
            Owner.OnInstructedToReceiveBall -= Instance_OnInstructedToReceiveBall;
            Owner.OnInstructedToWait -= Instance_OnWait;

            // make sure I'm not picked out
            Owner.SupportSpot.SetIsNotPickedOut();
        }

        private void Instance_OnInstructedToGoToHome()
        {
            Machine.ChangeState<GoToHomeMainState>();
        }

        private void Instance_OnInstructedToReceiveBall(float time, Vector3 position)
        {
            //get the receive ball state and init the steering target
            Machine.GetState<ReceiveBallMainState>().SetSteeringTarget(time, position);
            Machine.ChangeState<ReceiveBallMainState>();
        }

        private void Instance_OnWait()
        {
            Machine.ChangeState<WaitMainState>();
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
