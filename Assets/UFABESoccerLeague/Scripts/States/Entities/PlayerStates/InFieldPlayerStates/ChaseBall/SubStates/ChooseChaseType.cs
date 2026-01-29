using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.StateMachines.Entities;
using RobustFSM.Base;

namespace Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.ChaseBall.SubStates
{
    public class ChooseChaseType : BState
    {
        public override void Enter()
        {
            base.Enter();

            if (Owner.IsUserControlled)
                Machine.ChangeState<ManualChase>();
            else
                Machine.ChangeState<AutomaticChase>();
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
