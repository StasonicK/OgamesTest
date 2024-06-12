using UnityEngine;

namespace GamePlay.Ball
{
    public class BallRotation : MonoBehaviour
    {
        private Transform _cubeTransform;
        private bool _rotate;
        private Vector3 _directionToLook;
        private Quaternion _targetRotation;

        private void Update()
        {
            if (_cubeTransform && _rotate)
                RotateTowardsCube();
        }

        private void RotateTowardsCube()
        {
            Vector3 targetDirection = _cubeTransform.position - transform.position;
            // float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 1000f, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            _rotate = false;
            // UpdatePositionToLookAt();
            // _targetRotation = TargetRotation(_directionToLook);
            // transform.rotation = TargetRotation(_directionToLook);
            // transform.rotation = SmoothedRotation(transform.rotation, _targetRotation);
            // transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
        }

        private void UpdatePositionToLookAt()
        {
            Vector3 positionDelta = _cubeTransform.position - transform.position;
            _directionToLook = new Vector3(positionDelta.x, transform.position.y, positionDelta.z).normalized;
        }

        private Quaternion TargetRotation(Vector3 position) =>
            Quaternion.LookRotation(position, Vector3.up);

        // private Quaternion SmoothedRotation(Quaternion rotation, Quaternion targetRotation) =>
        //     Quaternion.Lerp(rotation, targetRotation, SpeedFactor());

        // private float SpeedFactor() =>
        //     _speed * Time.deltaTime;

        public void SetTarget(Transform cubeTransform) =>
            _cubeTransform = cubeTransform;

        public void SetRotate() =>
            _rotate = true;
    }
}