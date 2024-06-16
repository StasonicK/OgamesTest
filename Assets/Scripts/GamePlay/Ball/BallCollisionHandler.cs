using Cysharp.Threading.Tasks;
using GamePlay.Cube;
using GamePlay.Human;
using GamePlay.Pools;
using UnityEngine;

namespace GamePlay.Ball
{
    public class BallCollisionHandler : MonoBehaviour
    {
        private BallMovement _ball;

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag(Constants.FLOOR_TAG) || other.collider.CompareTag(Constants.WALL_TAG))
            {
                _ball = GetComponent<BallMovement>();
                _ball.SetStop();
                BallsPool.Instance.Release(_ball);
            }
            else if (other.collider.TryGetComponent(out CubeMovement cubeMovement))
            {
                ShootCubeSelector.Instance.CheckHitCube(cubeMovement);
                _ball = GetComponent<BallMovement>();
                _ball.SetStop();
                BallsPool.Instance.Release(_ball);
            }
        }
    }
}