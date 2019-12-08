using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkyWay : MonoBehaviour
{
    [SerializeField]
    private float power = 1.0f;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meteorite"))
        {
            var rigidbody = collision.gameObject.GetComponentInParent<Rigidbody2D>();
            rigidbody.AddForce(this.transform.up * power);
            SoundMng.Instance?.PlaySE(SoundMng.SETag.MilkyRoad);
            Debug.Log("IsHit!!");
        }
    }
}
