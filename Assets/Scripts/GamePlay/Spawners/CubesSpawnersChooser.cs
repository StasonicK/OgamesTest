using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Spawners
{
    public class CubesSpawnersChooser : MonoBehaviour
    {
        [SerializeField] private CubeSpawner[] _cubeSpawners;
        [SerializeField] private int _cubesCount;
        [SerializeField] private CubeMaterialGetter _cubeMaterialGetter;
        [SerializeField] private int _spawnDelaySec;

        private const int SEC_TO_MILLISECS_MULTIPLIER = 1000;
        private int _cubeCounter = 0;

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