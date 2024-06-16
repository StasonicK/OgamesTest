using UnityEngine;

namespace GamePlay.Cube
{
    public class TouchedCubeForPrayChecker : MonoBehaviour
    {
        private int _targetNumber;

        public void SetTargetNumber(int number) =>
            _targetNumber = number;

        public bool Check(int number)
        {
            if (number == _targetNumber)
                return true;

            return false;
        }
    }
}