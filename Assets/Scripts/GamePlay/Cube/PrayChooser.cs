using UnityEngine;

namespace GamePlay.Cube
{
    public class PrayChooser : MonoBehaviour
    {
        [SerializeField] private LayerMask _enemyMask;
        [SerializeField] private float _radius;

        private const float MIN_DISTANCE = 0f;

        private static readonly int _raycastHitsArrayCount = 1000;

        private readonly RaycastHit[] _raycastHits = new RaycastHit[_raycastHitsArrayCount];
        private readonly float _maxSphereDistance = MIN_DISTANCE;
        private float _maxDistanceToEnemy;
        private RaycastHit _targetRaycastHit;

        public bool Choose(out CubeMovement target)
        {
            int count = Physics.SphereCastNonAlloc(transform.position, _radius, Vector3.forward, _raycastHits,
                _maxSphereDistance, _enemyMask, QueryTriggerInteraction.UseGlobal);

            float distance = 0f;

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    distance = Vector3.Distance(_raycastHits[i].transform.position, transform.position);

                    if (distance > 0f && distance > _maxDistanceToEnemy)
                    {
                        _maxDistanceToEnemy = distance;
                        _targetRaycastHit = _raycastHits[i];
                    }
                }
            }

            if (distance > 0f)
            {
                target = _targetRaycastHit.transform.gameObject.GetComponent<CubeMovement>();
                return true;
            }
            else
            {
                target = null;
                return false;
            }
        }
    }
}