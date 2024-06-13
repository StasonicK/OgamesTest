using UnityEngine;

namespace GamePlay.Cube
{
    [RequireComponent(typeof(CubeRandomRotation))]
    public class CubeMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private CubeRandomRotation _cubeRandomRotation;
        private int _directionMultiplier = 1;
        private bool _isRotated;
        private bool _isMovable;

        public bool OnGround { private set; get; }

        private void Awake()
        {
            _cubeRandomRotation = GetComponent<CubeRandomRotation>();
        }

        private void Update()
        {
            if (_isMovable && OnGround)
            {
                if (_isRotated == false)
                {
                    _cubeRandomRotation.Rotate();
                    _isRotated = true;
                }

                MoveTowards();
            }
        }

        private void MoveTowards() =>
            transform.position =
                Vector3.MoveTowards(transform.position,
                    transform.position + transform.forward * 10 * _directionMultiplier,
                    _speed * Time.deltaTime);

        public void SetMove() =>
            _isMovable = true;

        public void SetOnGround() =>
            OnGround = true;

        public void SetStop() =>
            _isMovable = false;

        public void ReverseDirection() =>
            _directionMultiplier = -_directionMultiplier;
    }
}