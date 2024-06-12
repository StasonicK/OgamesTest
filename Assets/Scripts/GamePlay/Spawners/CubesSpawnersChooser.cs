using Cysharp.Threading.Tasks;
using GamePlay.Cube;
using GamePlay.CubesController;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay.Spawners
{
    public class CubesSpawnersChooser : MonoBehaviour
    {
        [SerializeField] private CubeSpawner[] _cubeSpawners;
        [SerializeField] private CubeMaterialGetter _cubeMaterialGetter;
        [SerializeField] private float _spawnDelaySec;
        [SerializeField] private int _minCubesCount;
        [SerializeField] private int _maxCubesCount;
        [SerializeField] private CubesMoveExecutor _cubesMoveExecutor;

        private const int SEC_TO_MILLISECS_MULTIPLIER = 1000;

        private int _cubeCounter = 0;
        private int _cubesCount;
        private CubeMovement _cubeMovement;

        private void Awake()
        {
            _cubesCount = Random.Range(_minCubesCount, _maxCubesCount + 1);
            _cubesMoveExecutor.Initialize(_cubesCount);
        }

        public async UniTask SpawnCubes()
        {
            int cubeSpawnerNumber = 0;

            for (int i = 0; i < _cubesCount; i++)
            {
                cubeSpawnerNumber = _cubeCounter % _cubeSpawners.Length;

                _cubeMovement = _cubeSpawners[cubeSpawnerNumber]
                    .Spawn(_cubeCounter + 1, _cubeMaterialGetter.GetMaterial());
                _cubesMoveExecutor.Add(_cubeMovement);

                _cubeCounter++;
                await UniTask.Delay((int)(_spawnDelaySec * SEC_TO_MILLISECS_MULTIPLIER));
            }
        }
    }
}