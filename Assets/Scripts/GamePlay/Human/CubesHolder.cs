using System.Collections.Generic;
using GamePlay.Cube;
using UnityEngine;

namespace GamePlay.Human
{
    public class CubesHolder : MonoBehaviour
    {
        private Dictionary<int, CubeMovement> _inactiveCubesMovements;
        private Dictionary<int, CubeMovement> _activeCubesMovements;
        private Dictionary<int, CubeMovement> _hitCubesMovements;
        private int _number;

        public int InactiveCount => _inactiveCubesMovements.Count;
        public int ActiveCount => _activeCubesMovements.Count;

        private void Awake()
        {
            _inactiveCubesMovements = new Dictionary<int, CubeMovement>();
            _activeCubesMovements = new Dictionary<int, CubeMovement>();
            _hitCubesMovements = new Dictionary<int, CubeMovement>();
        }

        // public void AddAllCubes(List<CubeMovement> cubeMovements)
        // {
        //     for (int i = 0; i < cubeMovements.Count; i++) 
        //         _allCubesMovements.TryAdd(cubeMovements[i].GetComponent<CubeNumberSetter>().Number, cubeMovements[i]);
        // }

        public void AddCube(CubeMovement cubeMovement)
        {
            _number = cubeMovement.GetComponent<CubeNumberSetter>().Number;
            _inactiveCubesMovements.TryAdd(_number, cubeMovement);
        }

        public void AddHitCube(CubeMovement cubeMovement)
        {
            _number = cubeMovement.GetComponent<CubeNumberSetter>().Number;

            if (_hitCubesMovements.TryAdd(_number, cubeMovement))
                _activeCubesMovements.Remove(_number);
        }

        public bool GetRandomCube(out CubeMovement cubeMovement)
        {
            int index = Random.Range(0, _inactiveCubesMovements.Count);
            _number = _inactiveCubesMovements[index].GetComponent<CubeNumberSetter>().Number;

            if (_activeCubesMovements.TryAdd(_number, _inactiveCubesMovements[index]))
            {
                cubeMovement = _inactiveCubesMovements[index];
                _inactiveCubesMovements.Remove(index);
                return true;
            }

            cubeMovement = null;
            return false;
        }
    }
}