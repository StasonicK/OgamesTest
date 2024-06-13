using System.Collections.Generic;
using System.Linq;
using GamePlay.Cube;
using UI;
using UnityEngine;

namespace GamePlay.Human
{
    public class CubesHolder : MonoBehaviour
    {
        private const int ATTACKED_CUBES_CAPACITY = 1;

        private static CubesHolder _instance;

        private Dictionary<int, CubeMovement> _inactiveCubesMovements;
        private Dictionary<int, CubeMovement> _attackedCubesMovements;
        private Dictionary<int, CubeMovement> _hitCubesMovements;
        private int _number;

        public int InactiveCount => _inactiveCubesMovements.Count;
        public int ActiveCount => _attackedCubesMovements.Count;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _inactiveCubesMovements = new Dictionary<int, CubeMovement>();
            _attackedCubesMovements = new Dictionary<int, CubeMovement>(ATTACKED_CUBES_CAPACITY);
            _hitCubesMovements = new Dictionary<int, CubeMovement>();
        }

        public static CubesHolder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<CubesHolder>();

                return _instance;
            }
        }

        public void AddCube(CubeMovement cubeMovement)
        {
            _number = cubeMovement.GetComponent<CubeNumberSetter>().Number;
            _inactiveCubesMovements.TryAdd(_number, cubeMovement);
        }

        public void AddHitCube(CubeMovement cubeMovement)
        {
            _number = cubeMovement.GetComponent<CubeNumberSetter>().Number;

            if (_hitCubesMovements.TryAdd(_number, cubeMovement))
            {
                _attackedCubesMovements.Remove(_number);
                AttackingCubeNumberShower.Instance.Clear();
            }
        }

        public bool GetRandomCube(out CubeMovement cubeMovement)
        {
            int index = Random.Range(0, _inactiveCubesMovements.Count);
            _number = _inactiveCubesMovements.ElementAt(index).Value.GetComponent<CubeNumberSetter>().Number;

            if (_attackedCubesMovements.TryAdd(_number, _inactiveCubesMovements.ElementAt(index).Value))
            {
                cubeMovement = _inactiveCubesMovements.ElementAt(index).Value;
                AttackingCubeNumberShower.Instance.SetNumber($"{_number}");
                _inactiveCubesMovements.Remove(_number);
                return true;
            }

            cubeMovement = null;
            return false;
        }
    }
}