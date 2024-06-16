using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using GamePlay.Cube;
using GamePlay.CubesController;
using UnityEngine;

namespace GamePlay.Human
{
    [RequireComponent(typeof(BallShooting))]
    public class ShootCubeSelector : MonoBehaviour
    {
        [SerializeField] private float _shootDelay;

        private static ShootCubeSelector _instance;

        private BallShooting _ballShooting;
        private CubeMovement _attackedCube;
        private int _attackedCubeNumber;

        public static ShootCubeSelector Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<ShootCubeSelector>();

                return _instance;
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _ballShooting = GetComponent<BallShooting>();
        }

        public async UniTask StartAttackMode()
        {
            while (ShotableCubesHolder.Instance.AliveCount > 0 || ShotableCubesHolder.Instance.AttackedCubeExists)
            {
                if (_attackedCube == null)
                {
                    if (ShotableCubesHolder.Instance.GetRandomShotCube(out CubeMovement cubeMovement))
                    {
                        _attackedCube = cubeMovement;
                        _attackedCubeNumber = cubeMovement.GetComponent<CubeNumberHolder>().Number;
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
            _ballShooting.Shoot(_attackedCube.transform);
            await UniTask.Delay((int)(_shootDelay * Constants.SEC_TO_MILLISECS_MULTIPLIER));
        }

        public void CheckHitCube(CubeMovement cube)
        {
            if (cube.GetComponent<CubeNumberHolder>().Number == _attackedCubeNumber)
            {
                _attackedCube = null;
                cube.SetStop();
                ShotableCubesHolder.Instance.AddHitCube(cube);
            }
        }
    }
}