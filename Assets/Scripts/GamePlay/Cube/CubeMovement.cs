using UnityEngine;

namespace GamePlay.Cube
{
    [RequireComponent(typeof(CubeRotation))]
    public class CubeMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private CubeRotation _cubeRotation;
        private int _directionMultiplier = 1;
        private bool _isRotated;
        private bool _onGround;
        private bool _isMovable;
        private bool _chasePray;
        private Transform _target;

        private void Awake()
        {
            _cubeRotation = GetComponent<CubeRotation>();
        }

        private void Update()
        {
            if (_isMovable && _onGround)
            {
                if (_chasePray)
                {
                    if (_target == null)
                        return;

                    _cubeRotation.RotateToTarget(_target.position);
                    MoveToTarget();
                }
                else
                {
                    if (_isRotated == false)
                    {
                        _cubeRotation.RotateToRandomDirection();
                        _isRotated = true;
                    }

                    MoveTowards();
                }
            }
        }

        private void MoveToTarget() =>
            transform.position =
                Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        private void MoveTowards() =>
            transform.position =
                Vector3.MoveTowards(transform.position, transform.position + transform.forward * _directionMultiplier,
                    _speed * Time.deltaTime);

        public void SetMovementToTarget(Transform target)
        {
            _chasePray = true;
            _target = target;
            SetMovable();
        }

        public void SetForwardMovement()
        {
            _chasePray = false;
            SetMovable();
        }

        public void SetMovable() =>
            _isMovable = true;

        public void SetOnGround() =>
            _onGround = true;

        public void SetStop() =>
            _isMovable = false;

        public void ReverseDirection() =>
            _directionMultiplier = -_directionMultiplier;
    }
}