using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using GamePlay.Cube;
using GamePlay.Spawners;
using UnityEngine;

namespace GamePlay.Human
{
    public class AttackedCubeSelector : MonoBehaviour
    {
        [SerializeField] private CubesHolder _cubesHolder;
        [SerializeField] private ShootCube _shootCube;
        [SerializeField] private float _shootDelay;

        private static AttackedCubeSelector _instance;

        private CubeMovement _attackedCubeMovement;
        private int _attackedCubeNumber;

        public static AttackedCubeSelector Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<AttackedCubeSelector>();

                return _instance;
            }
        }

        private void Awake() =>
            DontDestroyOnLoad(this);

        public async UniTask StartAttackMode()
        {
            while (_cubesHolder.InactiveCount > 0 || _cubesHolder.ActiveCount > 0)
            {
                if (_attackedCubeMovement == null)
                {
                    if (_cubesHolder.GetRandomCube(out CubeMovement cubeMovement))
                    {
                        _attackedCubeMovement = cubeMovement;
                        _attackedCubeNumber = cubeMovement.GetComponent<CubeNumberSetter>().Number;
                        await Shoot();
                    }
                }
                else
                {
                    await Shoot();
                }
            }
        }

        private async Task Shoot()
        {
            _shootCube.Shoot(_attackedCubeMovement.transform);
            await UniTask.Delay((int)(_shootDelay * Constants.SEC_TO_MILLISECS_MULTIPLIER));
        }

        public void CheckHitCube(CubeMovement cubeMovement)
        {
            if (cubeMovement.GetComponent<CubeNumberSetter>().Number == _attackedCubeNumber)
            {
                _attackedCubeMovement = null;
                cubeMovement.SetStop();
                CubesHolder.Instance.AddHitCube(cubeMovement);
            }
        }
    }
}