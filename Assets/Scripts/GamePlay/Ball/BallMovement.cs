using UnityEngine;

namespace GamePlay.Ball
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private bool _isMove;

        private void Update()
        {
            if (_isMove)
                transform.position += transform.forward * _speed * Time.deltaTime;
        }

        public void Move() =>
            _isMove = true;
    }
}