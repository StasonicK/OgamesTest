using UnityEngine;

namespace GamePlay.Cube
{
    [RequireComponent(typeof(CubeMovement))]
    [RequireComponent(typeof(CubeRandomRotation))]
    public class CubeCollisionHandler : MonoBehaviour
    {
        private CubeMovement _cubeMovement;
        private bool _inCollision;
        private bool _onGround;

        private void Awake()
        {
            _cubeMovement = GetComponent<CubeMovement>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out CubeCollisionHandler cubeCollisionHandler))
                TryReverseMovement();
            else if (other.collider.CompareTag(Constants.WALL_TAG))
                TryReverseMovement();
            else if (other.collider.CompareTag(Constants.FLOOR_TAG))
            {
                if (_onGround == false)
                {
                    _cubeMovement.SetOnGround();
                    _onGround = true;
                }
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.collider.TryGetComponent(out CubeCollisionHandler cubeCollisionHandler))
                _inCollision = false;
            else if (other.collider.CompareTag(Constants.WALL_TAG))
                _inCollision = false;
        }

        private void TryReverseMovement()
        {
            if (_inCollision == false)
            {
                _inCollision = true;
                _cubeMovement.ReverseDirection();
            }
        }
    }
}