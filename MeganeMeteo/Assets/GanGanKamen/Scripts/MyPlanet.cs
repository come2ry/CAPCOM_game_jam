using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlanet : MonoBehaviour
{
    [SerializeField] private GameObject planet;
    [SerializeField] private float rotateSpeed;

    public GameObject meteoPrefab;
    public int bulletNum;
    private int preBulletNum;
    [SerializeField] private int maxNulletNum;
    [SerializeField] private Transform muzzle;
    [SerializeField] public float chargeTime;
    [SerializeField] private float coolDownTime;
    public bool canShoot = false;
    private bool isCharging = false;
    public float chargeCount = 0;
    private float coolDownCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        preBulletNum = bulletNum;
    }

    // Update is called once per frame
    void Update()
    {
        ShootCoolDown();
        ChargeBullet();
    }

    public void PlanetRotate(float axis)
    {
        planet.transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime * axis);
    }

    public void Fire()
    {
        if (canShoot == false || bulletNum <= 0)
        {
            return;
        }
        GameObject planetObj = Instantiate(meteoPrefab, muzzle.position, muzzle.rotation);
        bulletNum -= 1;
        canShoot = false;
    }

    private void ShootCoolDown()
    {
        if(canShoot == false)
        {
            if (coolDownCount >= coolDownTime)
            {
                canShoot = true;
                coolDownCount = 0;
            }
            else
            {
                coolDownCount += Time.deltaTime;
            }
        }
    }

    private void ChargeBullet()
    {
        if(preBulletNum != bulletNum)
        {
            preBulletNum = bulletNum;

        }
        if (bulletNum < maxNulletNum)
        {
            isCharging = true;
        }

        if (isCharging)
        {
            if(chargeCount >= chargeTime)
            {
                chargeCount = 0;
                bulletNum++;
                isCharging = false;
            }
            else
            {
                chargeCount += Time.deltaTime;
            }
        }
    }

}
