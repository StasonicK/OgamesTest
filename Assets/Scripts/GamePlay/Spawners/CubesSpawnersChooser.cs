using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay.Spawners
{
    public class CubesSpawnersChooser : MonoBehaviour
    {
        [SerializeField] private CubeSpawner[] _cubeSpawners;
        [SerializeField] private CubeMaterialGetter _cubeMaterialGetter;
        [SerializeField] private int _spawnDelaySec;
        [SerializeField] private int _minCubesCount;
        [SerializeField] private int _maxCubesCount;

        private const int SEC_TO_MILLISECS_MULTIPLIER = 1000;

        private int _cubeCounter = 0;
        private int _cubesCount;

        private void Awake()
        {
            _cubesCount = Random.Range(_minCubesCount, _maxCubesCount + 1);
        }

        public async UniTask SpawnCubes()
        {
            int cubeSpawnerNumber = 0;

            for (int i = 0; i < _cubesCount; i++)
            {
                cubeSpawnerNumber = _cubeCounter % _cubeSpawners.Length;
                _cubeSpawners[cubeSpawnerNumber].Spawn(_cubeCounter + 1, _cubeMaterialGetter.GetMaterial());
                _cubeCounter++;
                await UniTask.Delay(_spawnDelaySec * SEC_TO_MILLISECS_MULTIPLIER);
            }
        }
    }
}