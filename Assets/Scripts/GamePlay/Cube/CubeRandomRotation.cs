using UnityEngine;

namespace GamePlay.Cube
{
    public class CubeRandomRotation : MonoBehaviour
    {
        private const int MinYAngle = 0;
        private const int MaxYAngle = 361;

        public void Rotate()
        {
            transform.rotation.ToAngleAxis(out float angle, out Vector3 axis);
            float angleY = Random.Range(MinYAngle, MaxYAngle);
            transform.rotation = Quaternion.Euler(axis.x, angleY, axis.z);
        }
    }
}