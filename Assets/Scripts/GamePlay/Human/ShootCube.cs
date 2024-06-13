using GamePlay.Ball;
using UnityEngine;

namespace GamePlay.Human
{
    public class ShootCube : MonoBehaviour
    {
        [SerializeField] private BallMovement _ballPrefab;
        [SerializeField] private Transform _respawnTransform;

        private BallMovement _ballMovement;
        private BallRotation _ballRotation;

        public void Shoot(Transform cubeTransform)
        {
            _ballMovement = Instantiate(_ballPrefab, _respawnTransform.position, Quaternion.identity);
            _ballRotation = _ballMovement.GetComponent<BallRotation>();
            _ballRotation.SetTarget(cubeTransform);
            _ballRotation.SetRotate();
            _ballMovement.Move();
        }
    }
}