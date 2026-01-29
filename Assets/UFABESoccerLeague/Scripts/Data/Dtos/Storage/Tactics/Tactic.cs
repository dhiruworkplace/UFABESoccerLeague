using System;
using UnityEngine;

namespace Assets.UFABESoccerLeague_.Scripts.Tactics
{
    [Serializable]
    public class Tactic
    {
        [SerializeField]
        string _name;

        public string Name { get => _name; set => _name = value; }
    }
}
