using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.StateMachines.Entities;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.GoalKeeperStates.GoToHome.MainState;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.GoalKeeperStates.Wait.MainState;
using Assets.UFABESoccerLeague_.Scripts.Entities;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.GoalKeeperStates.ChaseBall.SubStates;
using Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.GoalKeeperStates.PutBallBackIntoPlay.SubStates;
using RobustFSM.Base;

namespace Assets.UFABESoccerLeague_.Scripts.States.Entities.PlayerStates.GoalKeeperStates.PutBallBackIntoPlay.MainState
{
    public class PutBallBackIntoPlayMainState : BHState
    {
        public Player Owner { get => ((GoalKeeperFSM) SuperMachine).Owner; }

        public override void AddStates()
        {
            base.AddStates();

            // add states
            AddState<RecoverFromKick>();
            AddState<TakeCounterKick>();

            // set initial state
            SetInitialState<TakeCounterKick>();
        }

        public override void Enter()
        {
            base.Enter();

            //listen to variaus events
            Owner.OnInstructedToGoToHome += Instance_OnInstructedToGoToHome;
            Owner.OnInstructedToWait += Instance_OnWait;

            // enable the player widget
            Owner.PlayerNameInfoWidget.Root.SetActive(true);
        }

        public override void Exit()
        {
            base.Exit();

            //stop listening to variaus events
            Owner.OnInstructedToGoToHome -= Instance_OnInstructedToGoToHome;
            Owner.OnInstructedToWait -= Instance_OnWait;

            // disable the player widget
            Owner.PlayerNameInfoWidget.Root.SetActive(false);
        }

        public void Instance_OnInstructedToGoToHome()
        {
            // go to home
            Machine.ChangeState<GoToHomeMainState>();
        }

        private void Instance_OnWait()
        {
            Machine.ChangeState<WaitMainState>();
        }
    }
}
