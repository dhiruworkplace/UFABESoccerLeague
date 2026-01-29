using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.StateMachines.Entities;
using Assets.UFABESoccerLeague.Scripts.States.Entities.TeamStates.Defend.MainState;
using Assets.UFABESoccerLeague.Scripts.Utilities;
using RobustFSM.Base;

namespace Assets.UFABESoccerLeague_.Scripts.States.Entities.Team.CounterKick.SubStates
{
    public class DefendCounterKick : BState
    {
        float _lengthPitch = 90;

        public override void Enter()
        {
            base.Enter();

            // move players upfield
            Owner.MovePlayersUpField(_lengthPitch, -0.35f, Ball.Instance.Position);
            Owner.Players.ForEach(tM =>
            {
                tM.Player.IsTeamInControl = false;
                ActionUtility.Invoke_Action(tM.Player.OnInstructedToGoToHome);
            });

            //listen to some team events
            Owner.Opponent.GoalKeeper.OnPutBallBackIntoPlay += Instance_OnPutBallBackIntoPlay;
        }

        public override void Exit()
        {
            base.Exit();

            //stop listening to some team events
            Owner.GoalKeeper.OnPutBallBackIntoPlay -= Instance_OnPutBallBackIntoPlay;
        }

        private void Instance_OnPutBallBackIntoPlay()
        {
            SuperMachine.ChangeState<DefendMainState>();
        }

        public UFABESoccerLeague.Scripts.Entities.Team Owner
        {
            get
            {
                return ((TeamFSM)SuperMachine).Owner;
            }
        }
    }
}
