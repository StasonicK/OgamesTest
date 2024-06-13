using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AttackingCubeNumberShower : MonoBehaviour
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private TextMeshProUGUI _number;

        private static AttackingCubeNumberShower _instance;

        public static AttackingCubeNumberShower Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<AttackingCubeNumberShower>();

                return _instance;
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            Clear();
        }

        public void SetNumber(string number)
        {
            _backgroundImage.gameObject.SetActive(true);
            _number.text = number;
        }

        public void Clear()
        {
            _backgroundImage.gameObject.SetActive(false);
            _number.text = "";
        }
    }
}