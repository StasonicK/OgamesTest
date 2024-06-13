using DG.Tweening;
using UnityEngine;

namespace GamePlay.Cube
{
    public class CubeSizeUpScaler : MonoBehaviour
    {
        [SerializeField] private float _scaleUpSize;
        [SerializeField] private float _scaleDuration;
        [SerializeField] private bool _launchAtStart;

        private bool _isScaledUp;

        private void Start()
        {
            if (_launchAtStart)
                UpScale();
        }

        public void UpScale()
        {
            if (_isScaledUp)
                return;

            transform.DOScale(_scaleUpSize, _scaleDuration);
            _isScaledUp = true;
        }
    }
}