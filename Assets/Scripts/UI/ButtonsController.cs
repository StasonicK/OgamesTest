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
        [SerializeField] private Button _button1;
        [SerializeField] private Button _button2;
        [SerializeField] private Button _button3;
        [SerializeField] private Button _button4;
        [SerializeField] private CubesSpawnersChooser _cubesSpawnersChooser;
        [SerializeField] private CubesMoveExecutor _cubesMoveExecutor;
        [SerializeField] private AttackedCubeSelector _attackedCubeSelector;

        private void Awake()
        {
            _button1.onClick.AddListener(OnButton1Click);
            _button2.onClick.AddListener(OnButton2Click);
            _button3.onClick.AddListener(OnButton3Click);
            _button4.onClick.AddListener(OnButton4Click);
        }

        private void OnButton1Click()
        {
            Debug.Log("OnButton1Click");
            _cubesSpawnersChooser.SpawnCubes().Forget();
            _button1.enabled = false;
        }

        private void OnButton2Click()
        {
            Debug.Log("OnButton2Click");
            _cubesMoveExecutor.ForceMoveAll();
            _button2.enabled = false;
        }

        private void OnButton3Click()
        {
            Debug.Log("OnButton3Click");
            _attackedCubeSelector.StartAttackMode().Forget();
            _button3.enabled = false;
        }

        private void OnButton4Click()
        {
            Debug.Log("OnButton4Click");
            _button4.enabled = false;
        }
    }
}