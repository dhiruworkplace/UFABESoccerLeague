using Assets.UFABESoccerLeague.Scripts.StateMachines.Entities;
using Assets.UFABESoccerLeague.Scripts.Utilities.Enums;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.Team.CounterKick.MainState;
using RobustFSM.Base;
using System.Linq;

namespace Assets.UFABESoccerLeague_.Scripts.States.Entities.Team.CounterKick.SubStates
{
    public class PrepareForCounterKick : BState
    {
        public override void Enter()
        {
            base.Enter();

            // raise the team wait event
            Owner.Players.ToList()
                .Where(p => p.Player.PlayerType == PlayerTypes.InFieldPlayer)
                .ToList()
                .ForEach(tM => tM.Player.Invoke_OnInstructedToWait());

            // get data
            bool goalKeeperHasBall = SuperMachine.GetState<CounterKickMainState>().GoalKeeperHasBall;

            // decide which state to go to
            if (goalKeeperHasBall == true)
                Machine.ChangeState<AttackCounterKick>();
            else
                Machine.ChangeState<DefendCounterKick>();
        }

        public Assets.UFABESoccerLeague.Scripts.Entities.Team Owner
        {
            get
            {
                return ((TeamFSM)SuperMachine).Owner;
            }
        }
    }
}
