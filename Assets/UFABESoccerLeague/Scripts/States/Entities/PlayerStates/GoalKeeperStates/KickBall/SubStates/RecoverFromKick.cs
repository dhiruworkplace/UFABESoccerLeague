using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.StateMachines.Entities;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.GoalKeeperStates.GoToHome.MainState;
using Assets.UFABESoccerLeague_.Scripts.Shared;
using RobustFSM.Base;
using UnityEngine;

namespace Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.GoalKeeperStates.KickBall.SubStates
{
    public class RecoverFromKick : BState
    {
        float waitTime;

        public Player Owner { get => ((GoalKeeperFSM)SuperMachine).Owner; }

        public override void Enter()
        {
            base.Enter();

            //set the wait time 
            waitTime = Globals.RecoverFromKickWaitTime;
        }

        public override void Execute()
        {
            base.Execute();

            //decrement time
            waitTime -= Time.deltaTime;

            //go to home after state
            if (waitTime <= 0f && Owner.Animator.GetCurrentAnimatorStateInfo(2).IsName("New State"))
                SuperMachine.ChangeState<GoToHomeMainState>();
        }
    }
}
