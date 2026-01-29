using Assets.RobustFSM.Mono;
using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.GoalKeeperStates.GoToHome.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.GoalKeeperStates.Init.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.GoalKeeperStates.Wait.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.GoalKeeperStates.InteractWithBall.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.GoalKeeperStates.IdleState.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.GoalKeeperStates.PutBallBackIntoPlay.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.GoalKeeperStates.TakeGoalKick.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.GoalKeeperStates.ProtectGoal.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.GoalKeeperStates.ChaseBall.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.GoalKeeperStates.KickBall.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.GoalKeeperStates.InterceptShot.MainState;

namespace Assets.UFABESoccerLeague.Scripts.StateMachines.Entities
{
    public class GoalKeeperFSM : MonoFSM<Player>
    {
        public override void AddStates()
        {
            base.AddStates();

            // add states
            AddState<ChaseBallMainState>();
            AddState<GoToHomeMainState>();
            AddState<IdleMainState>();
            AddState<InitMainState>();
            AddState<InterceptShotMainState>();
            AddState<InteractWithBallMainState>();
            AddState<KickBallMainState>();
            AddState<PutBallBackIntoPlayMainState>();
            AddState<TakeGoalKickMainState>();
            AddState<ProtectGoalMainState>();
            AddState<WaitMainState>();

            // set initial states
            SetInitialState<InitMainState>();
        }
    }
}
