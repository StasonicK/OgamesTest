using System.Collections.Generic;
using GamePlay.Ball;
using UnityEngine;

namespace GamePlay.Pools
{
    public class BallsPool : MonoBehaviour
    {
        [SerializeField] private BallMovement _ballPrefab;
        [SerializeField] private int _initialCount;

        private static BallsPool _instance;

        private List<BallMovement> _activeBalls;
        private List<BallMovement> _inactiveBalls;
        private BallMovement _ball;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _activeBalls = new List<BallMovement>(_initialCount);
            _inactiveBalls = new List<BallMovement>(_initialCount);
            Initialize();
        }

        public static BallsPool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<BallsPool>();

                return _instance;
            }
        }

        private void Initialize()
        {
            for (int i = 0; i < _initialCount; i++)
            {
                _ball = Instantiate(_ballPrefab);
                _ball.gameObject.SetActive(false);
                _inactiveBalls.Add(_ball);
            }
        }

        public BallMovement Get()
        {
            if (_inactiveBalls.Count > 0)
            {
                _ball = _inactiveBalls[0];
                _inactiveBalls.Remove(_ball);
                _ball.gameObject.SetActive(true);
                _activeBalls.Add(_ball);
            }
            else
            {
                _ball = Instantiate(_ballPrefab);
                _activeBalls.Add(_ball);
            }

            return _ball;
        }

        public void Release(BallMovement ball)
        {
            ball.gameObject.SetActive(false);
            _inactiveBalls.Add(ball);
        }
    }
}