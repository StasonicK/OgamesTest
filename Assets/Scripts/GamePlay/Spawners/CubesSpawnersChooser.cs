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

        private static CubesSpawnersChooser _instance;

        private int _cubesCount;

        public static CubesSpawnersChooser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<CubesSpawnersChooser>();

                return _instance;
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _cubesCount = Random.Range(_minCubesCount, _maxCubesCount + 1);
            CubesMoveExecutor.Instance.Initialize(_cubesCount);
        }

        public async UniTask SpawnCubes()
        {
            int cubeSpawnerNumber = 0;
            int cubeCounter = 0;
            CubeMovement cube;
            int number = 0;

            for (int i = 0; i < _cubesCount; i++)
            {
                cubeSpawnerNumber = cubeCounter % _cubeSpawners.Length;
                cube = _cubeSpawners[cubeSpawnerNumber]
                    .Spawn(cubeCounter + 1, _cubeMaterialGetter.GetMaterial());
                number = cube.GetComponent<CubeNumberHolder>().Number;
                AddCube(cube, number);
                cubeCounter++;
                await UniTask.Delay((int)(_spawnDelaySec * Constants.SEC_TO_MILLISECS_MULTIPLIER));
            }
        }

        private void AddCube(CubeMovement cube, int number)
        {
            CubesMoveExecutor.Instance.Add(cube);
            ShotableCubesHolder.Instance.AddCube(cube, number);
            NonAggressiveCubesHolder.Instance.AddCube(cube, number);
        }
    }
}