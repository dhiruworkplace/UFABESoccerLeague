using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague.Scripts.States.Entities.PlayerStates.InFieldPlayerStates.GoToHome.MainState;
using UnityEngine;

namespace Assets.UFABESoccerLeague.Scripts.Tests.InFieldPlayerTests
{
    public class PlayerReturnToHomeTest : MonoBehaviour
    {
        public Player PlayerControlling;

        private void Start()
        {
            Invoke("Init", 1f);
        }

        void Init()
        {
            PlayerControlling.InFieldPlayerFSM.SetCurrentState<GoToHomeMainState>();
            PlayerControlling.InFieldPlayerFSM.GetState<GoToHomeMainState>().Enter();
            //PlayerControlling.Init(15f, 5f, 15f, 5f, 10f, 5f);
            PlayerControlling.Init();
        }
    }
}
