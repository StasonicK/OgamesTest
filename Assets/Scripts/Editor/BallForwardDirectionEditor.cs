using GamePlay.Ball;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class BallForwardDirectionEditor : UnityEditor.Editor
    {
        private static float _rayLength = 20f;
        private static Color _color = Color.green;

        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(BallForwardDirection ballForwardDirection, GizmoType gizmo)
        {
            Debug.DrawLine(ballForwardDirection.transform.position,
                ballForwardDirection.transform.position + ballForwardDirection.transform.forward * _rayLength, _color);
        }
    }
}