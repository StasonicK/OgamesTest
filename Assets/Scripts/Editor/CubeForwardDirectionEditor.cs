using GamePlay.Cube;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(CubeForwardDirection))]
    public class CubeForwardDirectionEditor : UnityEditor.Editor
    {
        private static float _rayLength;
        private static Color _color = Color.red;

        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(CubeForwardDirection cubeForwardDirection, GizmoType gizmo)
        {
            Debug.DrawLine(cubeForwardDirection.transform.position,
                cubeForwardDirection.transform.position + cubeForwardDirection.transform.forward * _rayLength, _color);
        }
    }
}