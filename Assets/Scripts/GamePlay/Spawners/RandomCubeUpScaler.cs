using System.Collections.Generic;
using GamePlay.Cube;
using UnityEngine;

namespace GamePlay.Spawners
{
    public class RandomCubeUpScaler : MonoBehaviour
    {
        private static RandomCubeUpScaler _instance;

        private List<CubeSizeUpScaler> _cubeSizeUpScalers;

        public static RandomCubeUpScaler Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<RandomCubeUpScaler>();

                return _instance;
            }
        }

        private void Awake()
        {
            _cubeSizeUpScalers = new List<CubeSizeUpScaler>();
        }

        public void Add(CubeSizeUpScaler cubeSizeUpScaler) => 
            _cubeSizeUpScalers.Add(cubeSizeUpScaler);

        public void ScaleUpRandomCube()
        {
            if (_cubeSizeUpScalers.Count == 0)
                return;

            int index = Random.Range(0, _cubeSizeUpScalers.Count);
            _cubeSizeUpScalers[index].GetComponent<CubeSizeUpScaler>().UpScale();
        }
    }
}