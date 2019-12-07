using UnityEngine;

public class PlanetPresenter : MonoBehaviour
{
    [SerializeField, Tooltip("重力ポイント情報")]
    private GravityPointInfo gravityPoint = default;

    [SerializeField, Tooltip("コライダーイベント")]
    private Collision2DEvent colliderEvent = default;

    [SerializeField, Tooltip("HPのイベント")]
    private HealthEvent healthEvent = default;

    [SerializeField, Tooltip("死亡処理")]
    private PlanetDestoryProcess destoryProcess = default;

    private void Start()
    {
        Subscribe();
    }

    /// <summary> 本体の衝突時時に通知が来る </summary>
    private void CollisionBody(Collision2D collision)
    {
        // 隕石と衝突したらダメージを与える
        if (collision.gameObject.CompareTag("Meteorite"))
        {
            healthEvent.ReceiveDamage(20);
        }
    }

    /// <summary> イベントを登録する </summary>
    private void Subscribe()
    {
        colliderEvent.CollisionEnterEvent += CollisionBody;

        healthEvent.DeadEvent += destoryProcess.Dead;
    }
}