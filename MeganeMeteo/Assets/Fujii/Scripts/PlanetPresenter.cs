using System;
using UnityEngine;

public class PlanetPresenter : MonoBehaviour
{
    [SerializeField, Tooltip("衝突対象のマスク")]
    private CollisionLayer collisionMask = (CollisionLayer)(-1);

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
        // 衝突対象と衝突したらダメージを与える
        if (((CollisionLayer)Enum.Parse(typeof(CollisionLayer), collision.gameObject.tag) & collisionMask) != 0)
        {
            healthEvent.ReceiveDamage(1);
        }
    }

    /// <summary> イベントを登録する </summary>
    private void Subscribe()
    {
        colliderEvent.CollisionEnterEvent += CollisionBody;

        healthEvent.DeadEvent += destoryProcess.Dead;
    }
}