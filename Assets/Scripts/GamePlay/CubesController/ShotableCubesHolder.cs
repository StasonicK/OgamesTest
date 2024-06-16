using System.Collections.Generic;
using System.Linq;
using GamePlay.Cube;
using UI;
using UnityEngine;

namespace GamePlay.CubesController
{
    public class ShotableCubesHolder : MonoBehaviour
    {
        private static ShotableCubesHolder _instance;

        private Dictionary<int, CubeMovement> _aliveCubes;
        private Dictionary<int, CubeMovement> _hitCubes;
        private CubeMovement _attackedCubeMovement;
        private CubeMovement _prayCube;
        private int _number;
        private int _index;

        public int AliveCount => _aliveCubes.Count;
        public bool AttackedCubeExists => _attackedCubeMovement != null;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _aliveCubes = new Dictionary<int, CubeMovement>();
            _hitCubes = new Dictionary<int, CubeMovement>();
        }

        public static ShotableCubesHolder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<ShotableCubesHolder>();

                return _instance;
            }
        }

        public void AddCube(CubeMovement cube, int number)
        {
            _number = number;
            _aliveCubes.TryAdd(_number, cube);
        }

        public void AddHitCube(CubeMovement cube)
        {
            _number = cube.GetComponent<CubeNumberHolder>().Number;

            if (_hitCubes.TryAdd(_number, cube))
            {
                _attackedCubeMovement = null;
                AttackingCubeNumberShower.Instance.Clear();
            }
        }

        public bool GetRandomShotCube(out CubeMovement randomCube)
        {
            if (_aliveCubes.Count == 0)
            {
                randomCube = null;
                return false;
            }

            _index = Random.Range(0, _aliveCubes.Count);
            _attackedCubeMovement = _aliveCubes.ElementAt(_index).Value;
            _number = _attackedCubeMovement.GetComponent<CubeNumberHolder>().Number;

            if (_attackedCubeMovement != null)
            {
                _aliveCubes.Remove(_number, out randomCube);
                // NonAggressiveCubesHolder.Instance.RemoveCube(_number);
                AttackingCubeNumberShower.Instance.SetNumber($"{_number}");
                return true;
            }

            randomCube = null;
            return false;
        }

        public void RemoveCube(int number) =>
            _aliveCubes.Remove(number);
    }
}