using Cysharp.Threading.Tasks;
using GamePlay.CubesController;
using GamePlay.Human;
using GamePlay.Spawners;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonsController : MonoBehaviour
    {
        [SerializeField] private Button _spawnCubesButton;
        [SerializeField] private Button _forceMoveAllButton;
        [SerializeField] private Button _startAttackModeButton;
        [SerializeField] private Button _button4;

        private void Awake()
        {
            _spawnCubesButton.onClick.AddListener(OnButton1Click);
            _forceMoveAllButton.onClick.AddListener(OnButton2Click);
            _startAttackModeButton.onClick.AddListener(OnButton3Click);
            _button4.onClick.AddListener(OnButton4Click);
        }

        private void OnButton1Click()
        {
            Debug.Log("OnButton1Click");
            CubesSpawnersChooser.Instance.SpawnCubes().Forget();
            _spawnCubesButton.enabled = false;
        }

        private void OnButton2Click()
        {
            Debug.Log("OnButton2Click");
            CubesMoveExecutor.Instance.ForceMoveAll();
            _forceMoveAllButton.enabled = false;
        }

        private void OnButton3Click()
        {
            Debug.Log("OnButton3Click");
            AttackedCubeSelector.Instance.StartAttackMode().Forget();
            _startAttackModeButton.enabled = false;
        }

        private void OnButton4Click()
        {
            Debug.Log("OnButton4Click");
            RandomCubeUpScaler.Instance.ScaleUpRandomCube();
            _button4.enabled = false;
        }
    }
}