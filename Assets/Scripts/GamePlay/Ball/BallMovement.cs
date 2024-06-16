using UnityEngine;

namespace GamePlay.Ball
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private bool _isMovable;

        private void Update()
        {
            if (_isMovable)
                transform.position += transform.forward * _speed * Time.deltaTime;
        }

        public void Move() =>
            _isMovable = true;
    }
}