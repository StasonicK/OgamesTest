using System.Linq;
using GamePlay.Cube;
using UnityEngine;

namespace GamePlay.CubesController
{
    public class AggressorChooser : MonoBehaviour
    {
        private static AggressorChooser _instance;

        public static AggressorChooser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<AggressorChooser>();

                return _instance;
            }
        }

        private void Awake() =>
            DontDestroyOnLoad(this);

        public void ChooseAggressor()
        {
            // NonAggressiveCubesHolder.Instance.RecoverNonAggressiveAliveCubes();
            CubesMoveExecutor.Instance.ForceSetMovableAll();

            int index = Random.Range(0, NonAggressiveCubesHolder.Instance.NonAggressiveAliveCubes.Count);
            var keyValuePair = NonAggressiveCubesHolder.Instance.NonAggressiveAliveCubes.ElementAt(index);
            NonAggressiveCubesHolder.Instance.RemoveCube(keyValuePair.Key);

            CubeMovement movement = keyValuePair.Value;
            movement.GetComponent<CubeCollisionHandler>().SetAggressorStatus();
            movement.GetComponent<CubeSizeUpScaler>().UpScale();

            if (movement.GetComponent<PrayChooser>().Choose(out CubeMovement target))
            {
                int number = target.GetComponent<CubeNumberHolder>().Number;
                movement.GetComponent<PrayCubeSetter>().SetPray(target.gameObject.transform);
                movement.GetComponent<TouchedCubeForPrayChecker>().SetTargetNumber(number);
            }
        }
    }
}