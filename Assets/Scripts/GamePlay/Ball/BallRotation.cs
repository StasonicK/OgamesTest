using UnityEngine;

namespace GamePlay.Ball
{
    public class BallRotation : MonoBehaviour
    {
        private Transform _cubeTransform;
        private bool _rotate;
        private Vector3 _directionToLook;
        private Quaternion _targetRotation;
        private Vector3 _additionalVector = new Vector3(0f, 0.5f, 0f);

        private void Update()
        {
            if (_cubeTransform && _rotate)
                RotateTowardsCube();
        }

        private void RotateTowardsCube()
        {
            Vector3 targetDirection = _cubeTransform.position + _additionalVector - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 1000f, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            _rotate = false;
        }

        public void SetTarget(Transform cubeTransform) =>
            _cubeTransform = cubeTransform;

        public void SetRotate() =>
            _rotate = true;
    }
}