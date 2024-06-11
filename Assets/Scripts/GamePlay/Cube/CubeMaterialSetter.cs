using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Cube
{
    public class CubeMaterialSetter : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetMaterial(Material material)
        {
            if (_meshRenderer != null)
                _meshRenderer.SetMaterials(new List<Material>() { material });
        }
    }
}