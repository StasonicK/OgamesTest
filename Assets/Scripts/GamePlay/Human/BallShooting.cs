using Cysharp.Threading.Tasks;
using GamePlay.Ball;
using GamePlay.Pools;
using UnityEngine;

namespace GamePlay.Human
{
    public class BallShooting : MonoBehaviour
    {
        [SerializeField] private BallMovement _ballPrefab;
        [SerializeField] private Transform _respawnTransform;

        private BallMovement _ballMovement;
        private BallRotation _ballRotation;

        public void Shoot(Transform cubeTransform)
        {
            _ballMovement = BallsPool.Instance.Get();
            _ballMovement.transform.position = _respawnTransform.position;
            _ballRotation = _ballMovement.GetComponent<BallRotation>();
            _ballRotation.SetTarget(cubeTransform);
            _ballRotation.SetRotate();
            _ballMovement.SetMovable();
            _ballMovement.GetComponent<BallLifetime>().Resume().Forget();
        }
    }
}