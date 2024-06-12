using GamePlay.Cube;
using UnityEngine;

namespace GamePlay.Ball
{
    public class BallCollisionHandler : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag(Constants.FLOOR_TAG) || other.collider.CompareTag(Constants.WALL_TAG))
            {
                Destroy(gameObject);
            }
            else if (other.collider.TryGetComponent(out CubeMovement cubeMovement))
            {
                cubeMovement.SetStop();
                // remove this from dict
                Destroy(gameObject);
            }
        }
    }
}