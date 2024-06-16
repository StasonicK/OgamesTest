using GamePlay.CubesController;
using UnityEngine;

namespace GamePlay.Cube
{
    [RequireComponent(typeof(CubeMovement))]
    [RequireComponent(typeof(TouchedCubeForPrayChecker))]
    public class CubeCollisionHandler : MonoBehaviour
    {
        private CubeMovement _cubeMovement;
        private TouchedCubeForPrayChecker _touchedCubeForPrayChecker;
        private PrayCubeSetter _prayCubeSetter;
        private bool _inCollision;
        private bool _onGround;
        private bool _isAggressor;
        private CubeMovement _nextPray;
        private int _number;

        private void Awake()
        {
            _cubeMovement = GetComponent<CubeMovement>();
            _touchedCubeForPrayChecker = GetComponent<TouchedCubeForPrayChecker>();
            _prayCubeSetter = GetComponent<PrayCubeSetter>();
        }

        public void SetAggressorStatus() =>
            _isAggressor = true;

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out CubeNumberHolder cubeNumberHolder))
            {
                if (_isAggressor)
                {
                    if (_touchedCubeForPrayChecker.Check(cubeNumberHolder.Number))
                    {
                        GoToNextPray(other, cubeNumberHolder);
                    }
                    else
                    {
                        RemoveCube(other, cubeNumberHolder);
                    }
                }
                else
                {
                    TryReverseMovement();
                }
            }
            else if (other.collider.CompareTag(Constants.WALL_TAG))
            {
                TryReverseMovement();
            }
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

        private void GoToNextPray(Collision other, CubeNumberHolder cubeNumberHolder)
        {
            RemoveCube(other, cubeNumberHolder);

            if (NonAggressiveCubesHolder.Instance.GetNextPray(out _nextPray))
            {
                _number = _nextPray.GetComponent<CubeNumberHolder>().Number;
                _prayCubeSetter.SetPray(_nextPray.gameObject.transform);
                _touchedCubeForPrayChecker.SetTargetNumber(_number);
            }
        }

        private void RemoveCube(Collision other, CubeNumberHolder cubeNumberHolder)
        {
            NonAggressiveCubesHolder.Instance.RemoveCube(cubeNumberHolder.Number);
            ShotableCubesHolder.Instance.RemoveCube(cubeNumberHolder.Number);
            Destroy(other.gameObject);
        }
    }
}