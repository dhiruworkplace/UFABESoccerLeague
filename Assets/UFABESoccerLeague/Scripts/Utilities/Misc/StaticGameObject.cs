using UnityEngine;

namespace Assets.UFABESoccerLeague_.Scripts.Utilities.Misc
{
    public class StaticGameObject : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
