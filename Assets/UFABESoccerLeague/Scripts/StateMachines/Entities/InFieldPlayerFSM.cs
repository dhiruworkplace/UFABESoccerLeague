using Assets.RobustFSM.Mono;
using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.ChaseBall.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.ControlBall.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.GoToHome.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.Init.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.KickBall.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.PickOutThreat.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.ReceiveBall.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.SupportAttacker.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.Tackled.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.TacklePlayer.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.TakeKickOff.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.Wait.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.TakeThrowIn.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.TakeCornerKick.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.SupportCornerKick.MainState;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.DefendCornerKick.MainState;

namespace Assets.UFABESoccerLeague.Scripts.StateMachines.Entities
{
    public class InFieldPlayerFSM : MonoFSM<Player>
    {
        public override void AddStates()
        {
            base.AddStates();

            //add the states
            AddState<ChaseBallMainState>();
            AddState<ControlBallMainState>();
            AddState<DefendCornerKickMainState>();
            AddState<GoToHomeMainState>();
            AddState<InitMainState>();
            AddState<KickBallMainState>();
            AddState<PickOutThreatMainState>();
            AddState<ReceiveBallMainState>();
            AddState<SupportAttackerMainState>();
            AddState<SupportCornerKickMainState>();
            AddState<TackleMainState>();
            AddState<TackledMainState>();
            AddState<TakeCornerKickMainState>();
            AddState<TakeKickOffMainState>();
            AddState<TakeThrowInMainState>();
            AddState<WaitMainState>();

            //set the inital state
            SetInitialState<InitMainState>();
        }
    }
}
