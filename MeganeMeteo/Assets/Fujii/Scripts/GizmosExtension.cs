using UnityEngine;
using UnityEditor;

/// <summary> ギズモの拡張クラス </summary>
public class GizmosExtension
{
    /// <summary> 視野範囲を描画します。 </summary>
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
    private static void DrawFov(GravityPointInfo info, GizmoType gizmoType)
    {
        if (info.Range <= 0f) { return; }
        if (info.Origin == null) { return; }

        Gizmos.color = info.Color;

        Vector3 pos = info.Origin.position;
        Quaternion rot = info.Origin.rotation;
        Vector3 scale = Vector3.one * info.Range * info.transform.localScale.x;

        Gizmos.DrawMesh(info.GravityRangeMesh, pos, rot * Quaternion.AngleAxis(90.0f, Vector3.right), scale);
    }
}