using GamePlay.Cube;
using UnityEngine;

namespace GamePlay.Spawners
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private CubeMaterialSetter _cubePrefab;

        private CubeMaterialSetter _newCube;
        private CubeMovement _cubeMovement;

        public CubeMovement Spawn(int number, Material material)
        {
            _newCube = Instantiate(_cubePrefab, transform);
            _newCube.SetMaterial(material);
            _newCube.GetComponent<CubeNumberHolder>().SetNumber(number);
            _cubeMovement = _newCube.GetComponent<CubeMovement>();
            return _cubeMovement;
        }
    }
}