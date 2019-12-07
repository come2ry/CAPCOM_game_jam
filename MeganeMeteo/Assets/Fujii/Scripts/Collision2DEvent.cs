using System;
using UnityEngine;

/// <summary> 衝突を通知する </summary>
public class Collision2DEvent : MonoBehaviour
{
    /// <summary> 衝突時に発生するイベント </summary>
    public event Action<Collision2D> CollisionEnterEvent;

    /// <summary> 衝突中に発生するイベント </summary>
    public event Action<Collision2D> CollisionStayEvent;

    /// <summary> 衝突をやめたときに発生するイベント </summary>
    public event Action<Collision2D> CollisionExitEvent;

    /// <summary> 衝突時に発生するイベント </summary>
    public event Action<Collider2D> TriggerEnterEvent;

    /// <summary> 衝突中に発生するイベント </summary>
    public event Action<Collider2D> TriggerStayEvent;

    /// <summary> 衝突をやめたときに発生するイベント </summary>
    public event Action<Collider2D> TriggerExitEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突時に通知する
        CollisionEnterEvent?.Invoke(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // 衝突中に通知する
        CollisionStayEvent?.Invoke(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 衝突をやめたとき通知する
        CollisionExitEvent?.Invoke(collision);
    }

    /********** コライダーのトリガーがオンの場合使う **********/

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 衝突時に通知する
        TriggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // 衝突中に通知する
        TriggerStayEvent?.Invoke(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 衝突をやめたとき通知する
        TriggerExitEvent?.Invoke(other);
    }
}