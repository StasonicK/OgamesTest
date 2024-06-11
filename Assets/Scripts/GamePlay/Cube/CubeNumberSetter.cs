using TMPro;
using UnityEngine;

namespace GamePlay.Cube
{
    public class CubeNumberSetter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] _numberTexts;

        private void Awake()
        {
            SetValue("");
        }

        public void SetValue(string value)
        {
            for (int i = 0; i < _numberTexts.Length; i++)
                _numberTexts[i].text = value;
        }
    }
}