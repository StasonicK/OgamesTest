using UnityEngine;

namespace GamePlay.Cube
{
    [RequireComponent(typeof(CubeMovement))]
    public class PrayCubeSetter : MonoBehaviour
    {
        private CubeMovement _cubeMovement;

        private void Awake() =>
            _cubeMovement = GetComponent<CubeMovement>();

        public void SetPray(Transform target) =>
            _cubeMovement.SetMovementToTarget(target);
    }
}