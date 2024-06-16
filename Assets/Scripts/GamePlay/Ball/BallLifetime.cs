using Cysharp.Threading.Tasks;
using GamePlay.Pools;
using UnityEngine;

namespace GamePlay.Ball
{
    public class BallLifetime : MonoBehaviour
    {
        [SerializeField] private float _lifetime;

        public async UniTask Resume()
        {
            await UniTask.Delay((int)(_lifetime * Constants.SEC_TO_MILLISECS_MULTIPLIER));
            BallsPool.Instance.Release(GetComponent<BallMovement>());
        }
    }
}