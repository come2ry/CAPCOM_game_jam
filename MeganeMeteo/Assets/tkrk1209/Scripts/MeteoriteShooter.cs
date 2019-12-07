using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteShooter : MonoBehaviour
{
    private float power = 100;
    private Rigidbody2D rb;
    [SerializeField, Tooltip("メテオレイ")]
    private GameObject MeteoRay;
    public GameObject RayInstance;

    // private bool IsShooted;
    //float speed;

    // Start is called before the first frame update
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Start() {
        // Vector3 NowVelVec3 = new Vector3(rb.velocity.x, rb.velocity.y, 0.0f);
        RayInstance = Instantiate(MeteoRay, transform.position, Quaternion.LookRotation(-rb.velocity*1000));
        // Instantiate(MeteoRay, transform.position, );
    }

    private void Update()
    {
        Vector2 NowPosition = transform.position;
        RayInstance.transform.rotation = Quaternion.LookRotation(-rb.velocity*1000);
        RayInstance.transform.position = transform.position;
        // Debug.DrawRay(NowPosition, rb.velocity*1000, Color.red, 2, false);

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

    public void Shoot(Vector2 force, float power)
    {
        rb.AddForce(force * power);
    }
}
