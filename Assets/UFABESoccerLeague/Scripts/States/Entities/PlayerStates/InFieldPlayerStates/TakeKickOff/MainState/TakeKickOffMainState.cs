using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.StateMachines.Entities;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.GoToHome.MainState;
using Assets.UFABESoccerLeague.Scripts.Utilities;
using Assets.UFABESoccerLeague_.Scripts.Entities;
using Assets.UFABESoccerLeague_.Scripts.Utilities.Enums;
using RobustFSM.Base;
using UnityEngine;

namespace Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.TakeKickOff.MainState
{
    /// <summary>
    /// Player takes the kick-off and broadcasts that he has done so
    /// </summary>
    public class TakeKickOffMainState : BState
    {
        public override void Enter()
        {
            base.Enter();

            //get a player to pass to
            Player receiver = Owner.GetRandomTeamMemberInRadius(20f);

            //find the power to target
            float power = Owner.FindPower(Ball.Instance.NormalizedPosition,
                receiver.Position,
                Owner.BallShortPassArriveVelocity,
                Ball.Instance.Friction);

            //clamp the power
            power = Mathf.Clamp(power, 0f, Owner.ActualPower);

            float time = Owner.TimeToTarget(Ball.Instance.Position,
                receiver.Position,
                power,
                Ball.Instance.Friction);

            // create a pass object
            Pass pass = new Pass()
            {
                BallTimeToTarget = time,
                KickPower = power,

                PassType = PassTypesEnum.Short,
                Receiver = receiver,

                FromPosition = Ball.Instance.Position,
                ToPosition = receiver.Position
            };

            //make a normal pass to the player
            Owner.MakePass(pass);

            ////broadcast that I have taken kick-off
            ActionUtility.Invoke_Action(Owner.OnTakeKickOff);

            //go to home state
            Machine.ChangeState<GoToHomeMainState>();
        }

        public override void Exit()
        {
            base.Exit();
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
