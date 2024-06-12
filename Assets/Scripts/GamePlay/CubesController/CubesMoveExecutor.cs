using System.Collections.Generic;
using GamePlay.Cube;
using UnityEngine;

namespace GamePlay.CubesController
{
    public class CubesMoveExecutor : MonoBehaviour
    {
        private List<CubeMovement> _cubeMovements;
        private bool _forceMove;

        public void Initialize(int count) =>
            _cubeMovements = new List<CubeMovement>(count);

        public void Add(CubeMovement cubeMovement)
        {
            if (_forceMove)
                cubeMovement.SetMove();

            _cubeMovements.Add(cubeMovement);
        }

        public void ForceMoveAll()
        {
            _forceMove = true;

            for (int i = 0; i < _cubeMovements.Count; i++)
            {
                // if (_cubeMovements[i].OnGround)
                _cubeMovements[i].SetMove();
            }
        }
    }
}