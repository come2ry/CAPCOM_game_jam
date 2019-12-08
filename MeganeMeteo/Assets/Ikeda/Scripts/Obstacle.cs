using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meteorite"))
        {
            MeteoriteDestoryProcess destoryProcess
                = collision.gameObject.transform.parent.GetComponent<MeteoriteDestoryProcess>();
            destoryProcess.Dead();
        }
    }
}
