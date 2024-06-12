using Cysharp.Threading.Tasks;
using GamePlay.Cube;
using UnityEngine;

namespace GamePlay.Human
{
    public class AttackedCubeSelector : MonoBehaviour
    {
        [SerializeField] private CubesHolder _cubesHolder;
        [SerializeField] private ShootCube _shootCube;
        [SerializeField] private float _shootDelay;

        private CubeMovement _cubeMovement;
        private bool _gotTarget;

        public async UniTask StartAttackMode()
        {
            while (_cubesHolder.InactiveCount > 0 || _cubesHolder.ActiveCount > 0)
            {
                if (_cubesHolder.GetRandomCube(out CubeMovement cubeMovement))
                {
                    _cubeMovement = cubeMovement;
                    _gotTarget = true;
                    _shootCube.Shoot(_cubeMovement.transform);
                    await UniTask.Delay((int)(_shootDelay * Constants.SEC_TO_MILLISECS_MULTIPLIER));
                }
            }
        }
    }
}