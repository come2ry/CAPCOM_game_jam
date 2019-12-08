using System;
using UnityEngine;

public class MeteoritePresenter : MonoBehaviour
{
    [SerializeField, Tooltip("衝突対象のマスク")]
    private CollisionLayer collisionMask = (CollisionLayer)(-1);

    [SerializeField, Tooltip("コライダーイベント")]
    private Collision2DEvent colliderEvent = default;

    [SerializeField, Tooltip("死亡処理")]
    private MeteoriteDestoryProcess destoryProcess = default;

    private void Start()
    {
        Subscribe();
    }

    /// <summary> 本体の衝突時時に通知が来る </summary>
    private void CollisionBody(Collision2D collision)
    {
        // 衝突対象と衝突したら死亡処理を呼ぶ
        if (((CollisionLayer)Enum.Parse(typeof(CollisionLayer), collision.gameObject.tag) & collisionMask) != 0)
        {
            destoryProcess.Dead();
        }
    }

    /// <summary> イベントを登録する </summary>
    private void Subscribe()
    {
        colliderEvent.CollisionEnterEvent += CollisionBody;
    }
}