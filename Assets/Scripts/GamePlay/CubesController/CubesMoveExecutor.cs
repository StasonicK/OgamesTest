using System.Collections.Generic;
using GamePlay.Cube;
using UnityEngine;

namespace GamePlay.CubesController
{
    public class CubesMoveExecutor : MonoBehaviour
    {
        private static CubesMoveExecutor _instance;

        private List<CubeMovement> _cubeMovements;
        private bool _needForceMove;

        public static CubesMoveExecutor Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<CubesMoveExecutor>();

                return _instance;
            }
        }

        public void Initialize(int count) =>
            _cubeMovements = new List<CubeMovement>(count);

        public void Add(CubeMovement cubeMovement)
        {
            if (_needForceMove)
                cubeMovement.SetForwardMovement();

            _cubeMovements.Add(cubeMovement);
        }

        public void ForceMoveForwardAll()
        {
            _needForceMove = true;

            for (int i = 0; i < _cubeMovements.Count; i++)
                _cubeMovements[i].SetForwardMovement();
        }

        public void ForceSetMovableAll()
        {
            _needForceMove = true;

            for (int i = 0; i < _cubeMovements.Count; i++)
                _cubeMovements[i].SetMovable();
        }
    }
}