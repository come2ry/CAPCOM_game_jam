using UnityEngine;

/// <summary> 重力ポイント情報クラス </summary>
public class GravityPointInfo : MonoBehaviour
{
    [SerializeField, Range(0, 10), Tooltip("重力の範囲")]
    private float range = 5f;

    [SerializeField, Range(-10, 10), Tooltip("重力の強さ")]
    private float intencity = 5f;

    [SerializeField, Tooltip("重力の中心点")]
    private Transform origin = default;

    [SerializeField, Tooltip("重力範囲の色")]
    private Color color = new Color(1f, 1f, 0f, 0.5f);

    [SerializeField, Range(1, 255), Tooltip("重力範囲を表示するメッシュのポリゴン数に影響します")]
    private int quality = 32;

    [SerializeField, Tooltip("PointEffector2D")]
    private PointEffector2D effecter = default;

    [SerializeField, Tooltip("重力の衝突範囲")]
    private CircleCollider2D collider = default;

    /// <summary> 重力の範囲 </summary>
    public float Range => range;

    /// <summary> 重力の強さ </summary>
    public float Intencity => intencity;

    /// <summary> 重力の中心点 </summary>
    public Transform Origin => origin;

    /// <summary> 重力の中心点 </summary>
    public Color Color => color;

    /// <summary> ギズモのクオリティ </summary>
    public int Quality => quality;

    /// <summary> 重力の表示に使うメッシュ </summary>
    public Mesh GravityRangeMesh { get; private set; }

    // インスペクターから変更があったらメッシュを再構築する
    private void OnValidate()
    {
        effecter.forceMagnitude = Intencity;
        collider.radius = Range;
        GravityRangeMesh = MeshCreater.CreateSectorMesh(360f * Mathf.Deg2Rad, quality);
    }
}