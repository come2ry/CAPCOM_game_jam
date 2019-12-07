using System;
using UnityEngine;

/// <summary> HPのイベント </summary>
public class HealthEvent : MonoBehaviour
{
    [SerializeField, Tooltip("現在の体力")]
    private int health = 100;

    /// <summary> 現在の体力 </summary>
    public int Health => health;

    /// <summary> ダメージを受けた時のイベント </summary>
    public event Action<int> DamageEvent = default;

    /// <summary> 死亡した時のイベント </summary>
    public event Action DeadEvent = default;

    /// <summary> ダメージを受けます。 </summary>
    /// <param name="damage"> ダメージ量 </param>
    public void ReceiveDamage(int damage)
    {
        if (damage < 0f)
        {
            throw new ArgumentOutOfRangeException("ダメージ量は正の値である必要があります。");
        }
        SetHealth(Health - damage);

        // ダメージを受けた時のイベントを通知する
        DeadEvent.Invoke();
    }

    /// <summary> 体力を回復します。 </summary>
    /// <param name="amount"> 回復量 </param>
    public void Recovery(int amount)
    {
        if (amount < 0f)
        {
            throw new ArgumentOutOfRangeException("回復量は正の値である必要があります。");
        }
        SetHealth(Health + amount);
    }

    /// <summary> 体力を設定します。 </summary>
    /// <param name="health"> 設定する体力 </param>
    public void SetHealth(int health)
    {
        this.health = health;

        // HPがなくなったら
        if (health <= 0)
        {
            // 死亡した時のイベントを通知する
            DeadEvent.Invoke();
        }
    }
}