using UnityEngine;

namespace GamePlay.Cube
{
    [RequireComponent(typeof(CubeRandomRotation))]
    public class CubeMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private CubeRandomRotation _cubeRandomRotation;
        private int _forward = 1;
        private bool _rotated;
        private bool _move;

        public bool OnGround { private set; get; }

        private void Awake()
        {
            _cubeRandomRotation = GetComponent<CubeRandomRotation>();
        }

        private void Update()
        {
            if (_move && OnGround)
            {
                if (_rotated == false)
                {
                    _cubeRandomRotation.Rotate();
                    _rotated = true;
                }

                MoveTowards();
            }
        }

        private void MoveTowards() =>
            transform.position =
                Vector3.MoveTowards(transform.position, transform.position + transform.forward * 10 * _forward,
                    _speed * Time.deltaTime);

        public void SetMove() =>
            _move = true;

        public void SetOnGround() =>
            OnGround = true;

        public void SetStop() =>
            _move = false;

        public void ReverseDirection() =>
            _forward = -_forward;
    }
}