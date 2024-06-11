using GamePlay.Cube;
using UnityEngine;

namespace GamePlay.Spawners
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private CubeMaterialSetter _cubePrefab;

        private CubeMaterialSetter _newCube;

        public void Spawn(int number, Material material)
        {
            _newCube = Instantiate(_cubePrefab, transform);
            _newCube.SetMaterial(material);

            if (_newCube.TryGetComponent(out CubeNumberSetter cubeNumberSetter))
                cubeNumberSetter.SetValue($"{number}");
        }
    }
}