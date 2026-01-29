using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.StateMachines.Entities;
using RobustFSM.Base;

namespace Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.GoalKeeperStates.IdleState.SubStates
{
    public class CheckIfHasBall : BState
    {
        public override void Enter()
        {
            base.Enter();

            //if the player has ball then hold ball
            //else check if player has to tend goal
            if (Owner.HasBall)
                Machine.ChangeState<HoldBall>();
            else
                Machine.ChangeState<CheckIfIHaveToTendGoal>();
        }

        Player Owner
        {
            get
            {
                return ((GoalKeeperFSM)SuperMachine).Owner;
            }
        }
    }
}
