using GamePlay.Spawners;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(CubeSpawner))]
    public class CubeSpawnerEditor : UnityEditor.Editor
    {
        private static float _radius = 0.5f;

        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(CubeSpawner spawner, GizmoType gizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spawner.transform.position, _radius);
        }
    }
}