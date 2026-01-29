using Assets.UFABESoccerLeague.Scripts.Entities;
using Assets.UFABESoccerLeague_.Scripts.Utilities.Enums;
using System;
using UnityEngine;

namespace Assets.UFABESoccerLeague_.Scripts.Entities
{
    public class Shot
    {
        public float BallTimeToTarget { get; set; }
        public float KickPower { get; set; }

        public ShotTypesEnum ShotTypeEnum { get; set; }

        public Vector3 FromPosition { get; set; }
        public Vector3 ToPosition { get; set; }

        public Player Receiver { get; set; }

        public override string ToString()
        {
            string stringValue = string.Format("BallTimeToTarget-{0} n/ KickPower-{1} n/ ShotType-{2} n/ FromPosition-{3} n/ ToPosition-{4} n/ Receiver-{5}", BallTimeToTarget, KickPower, ShotTypeEnum, FromPosition, ToPosition, Receiver);
            return stringValue;
        }

        public void Init(float ballTimeToTarget, float kickPower, ShotTypesEnum shotTypeEnum, Vector3 fromPosition, Vector3 toPosition, Player receiver)
        {
            BallTimeToTarget = ballTimeToTarget;
            KickPower = kickPower;
            ShotTypeEnum = shotTypeEnum;
            FromPosition = fromPosition;
            ToPosition = toPosition;
            Receiver = receiver;
        }
    }
}
