using System.Collections.Generic;
using System.Linq;
using GamePlay.Cube;
using UnityEngine;

namespace GamePlay.CubesController
{
    public class NonAggressiveCubesHolder : MonoBehaviour
    {
        private static NonAggressiveCubesHolder _instance;

        private Dictionary<int, CubeMovement> _cubes;
        private Dictionary<int, CubeMovement> _nonAggressiveAliveCubes;
        private CubeMovement _attackedCubeMovement;
        private CubeMovement _prayCube;
        private int _number;
        private int _index;

        public Dictionary<int, CubeMovement> NonAggressiveAliveCubes => _nonAggressiveAliveCubes;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _cubes = new Dictionary<int, CubeMovement>();
            _nonAggressiveAliveCubes = new Dictionary<int, CubeMovement>();
        }

        public static NonAggressiveCubesHolder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<NonAggressiveCubesHolder>();

                return _instance;
            }
        }

        public void AddCube(CubeMovement cube, int number)
        {
            _number = number;
            _cubes.TryAdd(_number, cube);
            _nonAggressiveAliveCubes.TryAdd(_number, cube);
        }

        public void RemoveCube(int number) =>
            _nonAggressiveAliveCubes.Remove(number);

        public bool GetNextPray(out CubeMovement pray)
        {
            if (_nonAggressiveAliveCubes.Count == 0)
            {
                pray = null;
                return false;
            }

            _index = Random.Range(0, _nonAggressiveAliveCubes.Count);
            _number = _nonAggressiveAliveCubes.ElementAt(_index).Key;
            _nonAggressiveAliveCubes.Remove(_number, out _prayCube);

            if (_prayCube != null)
            {
                pray = _prayCube;
                return true;
            }

            pray = null;
            return false;
        }
    }
}