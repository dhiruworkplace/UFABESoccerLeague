using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.StateMachines.Entities;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.GoalKeeperStates.ProtectGoal.MainState;
using RobustFSM.Base;

namespace Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.GoalKeeperStates.IdleState.SubStates
{
    public class CheckIfIHaveToTendGoal : BState
    {
        public Player Owner { get => ((GoalKeeperFSM)SuperMachine).Owner; }

        public override void Execute()
        {
            base.Execute();

            //if the ball is within threatening distance then tend goal
            if (Owner.IsBallPositionThreateningGoal())
                SuperMachine.ChangeState<ProtectGoalMainState>();
        }
    }
}
