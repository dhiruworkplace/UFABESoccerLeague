using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.StateMachines.Entities;
using RobustFSM.Base;
using System.Linq;

namespace Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.DefendCornerKick.SubStates
{
    public class FindCornerKickThreat : BState
    {
        public override void Enter()
        {
            base.Enter();

            // simply find a player in region
            Player threat = Owner.OppositionMembers
                .Where(oM => Owner.IsPositionWithinDistance(Owner.HomePosition.transform.position, oM.Position, 5f)
                &&  oM.IsPickedOut(Owner) == false)
                .FirstOrDefault();

            // if we have a threat switch to follow threat
            if (threat != null)
            {
                Machine.GetState<PickOutCornerKickThreat>().Threat = threat;
                Machine.ChangeState<PickOutCornerKickThreat>();
            }
            else
                Machine.ChangeState<FindRandomPointToDefendCornerKick>();
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
