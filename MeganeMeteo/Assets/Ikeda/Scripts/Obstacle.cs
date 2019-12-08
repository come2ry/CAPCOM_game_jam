using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private bool IsLife;
    [SerializeField]
    private int hp;

    private void Update()
    {
        if (IsLife && hp <= 0)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meteorite"))
        {
            if (IsLife) hp--;
            MeteoriteDestoryProcess destoryProcess
                = collision.gameObject.transform.parent.GetComponent<MeteoriteDestoryProcess>();
            destoryProcess.Dead();
        }
    }
}
