using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteShooter : MonoBehaviour
{
    private float power = 100;
    private bool IsShooted;
    //float speed;

    // Start is called before the first frame update
    void Start()
    {
        IsShooted = false;
    }

    private void Update()
    {
        /*
        if (!IsShooted && Input.GetKeyUp(KeyCode.Space))
        {
            IsShooted = true;
            Debug.Log("射出");
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(0.0f, 100.0f);
            rb.AddForce(force);
        }*/
    }

    public void Shoot(Vector2 force)
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        //Vector2 force = new Vector2(0.0f, 100.0f);
        rb.AddForce(force * power);
    }
}
