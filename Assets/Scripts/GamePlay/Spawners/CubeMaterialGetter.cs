using UnityEngine;

namespace GamePlay.Spawners
{
    public class CubeMaterialGetter : MonoBehaviour
    {
        [SerializeField] private Material[] _materials;

        private int _materialCounter = 0;
        private Material _currentMaterial;

        public Material GetMaterial()
        {
            _currentMaterial = _materials[_materialCounter % _materials.Length];
            _materialCounter++;
            return _currentMaterial;
        }
    }
}