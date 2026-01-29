using Assets.UFABESoccerLeague.Scripts.Managers;
using Assets.UFABESoccerLeague_.Scripts.Managers;
using RobustFSM.Base;
using UnityEngine;

namespace Assets.UFABESoccerLeague_.Scripts.States.Managers.GameManagerStates.GameOnState.SubStates.Init.SubStates
{
    public class WaitForSceneToInitialize : BState
    {
        public override void Enter()
        {
            base.Enter();

            // register to the initialized event on the match manager
            MatchManager.Instance.OnEnterWaitForMatchOnInstruction += Instance_OnSceneFinishedInitialization;

            // raise the initizlize event on the match manager
            MatchManager.Instance.Invoke_OnInitialize();
        }

        public override void Exit()
        {
            base.Exit();

            // enable the loading menu
            GraphicsManager.Instance
                .GameOnMainMenu
                .InitMenu
                .LoadMenu
                .Root.
                gameObject
                .SetActive(false);
        }

        private void Instance_OnSceneFinishedInitialization()
        {
            Machine.ChangeState<WaitForContinueToMatchOnInstruction>();
        }
    }
}
