using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlanet : MonoBehaviour
{
    [SerializeField] public bool hasBulletNum;
    [SerializeField] private GameObject planet;
    [SerializeField] private float rotateSpeed;

    public GameObject meteoPrefab;
    public int bulletNum;
    private int preBulletNum;
    [SerializeField] private float shootPower;
    [SerializeField] private int maxNulletNum;
    [SerializeField] private Transform muzzle;
    [SerializeField] public float chargeTime;
    [SerializeField] public float coolDownTime;
    public bool canShoot = false;
    private bool isCharging = false;
    public float chargeCount = 0;
    public float coolDownCount = 0;

    public int hp;
    private int preHp;

    [SerializeField]private bool invincible = false;
    [SerializeField] private float invincibleTime;
    [SerializeField] private float invincibleCount;

    [SerializeField] private MainGameScene gameScene;

    private MainGameSystem system;
    [SerializeField] private bool limit;
    [SerializeField] private Vector2 limitRotate;
    // Start is called before the first frame update
    private void Awake()
    {
        system = GameObject.FindGameObjectWithTag("System").GetComponent<MainGameSystem>();
    }

    void Start()
    {
        preBulletNum = bulletNum;
        preHp = hp;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        ShootCoolDown();
        if(hasBulletNum)ChargeBullet();
        HPChange();
        Debug.Log(planet.transform.rotation.eulerAngles);
    }

    public void PlanetRotate(float axis,int direction)
    {
        if (limit)
        {
            if (direction == 1)
            {
                if (planet.transform.eulerAngles.z < limitRotate.y)
                {
                    planet.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime * Mathf.Abs(axis));
                }

            }
            else if (direction == -1)
            {
                if (planet.transform.eulerAngles.z > limitRotate.x)
                {
                    planet.transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime * Mathf.Abs(axis));
                }

            }
        }
        else
        {
            planet.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime * axis);
        }
        
    }

    public void Fire(bool bulletNumLimit)
    {
        if (bulletNumLimit)
        {
            if (canShoot == false || bulletNum <= 0)
            {
                return;
            }
            GameObject planetObj = Instantiate(meteoPrefab, muzzle.position, muzzle.rotation);

            MeteoriteShooter shooter = planetObj.GetComponent<MeteoriteShooter>();
            Vector3 force = (muzzle.transform.position - planet.transform.position).normalized;
            shooter.Shoot(new Vector2(force.x, force.y), shootPower);
            bulletNum -= 1;
            canShoot = false;
        }
        else
        {
            if (canShoot == false)
            {
                return;
            }
            GameObject planetObj = Instantiate(meteoPrefab, muzzle.position, muzzle.rotation);

            MeteoriteShooter shooter = planetObj.GetComponent<MeteoriteShooter>();
            Vector3 force = (muzzle.transform.position - planet.transform.position).normalized;
            shooter.Shoot(new Vector2(force.x, force.y), shootPower);
            bulletNum -= 1;
            SoundMng.Instance?.PlaySE(SoundMng.SETag.Shoot);
            canShoot = false;
        }
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

    private void HPChange()
    {
        if(preHp != hp)
        {
            invincible = true;
            if(hp == 0 && system.gameOver == false && system != null)
            {
                system.GameOver(GetComponent<PlayerInput>().playerNum);
            }
            preHp = hp;
        }
        if (invincible)
        {
            if(invincibleCount >= invincibleTime)
            {
                invincibleCount = 0;
                invincible = false;
            }
            else
            {
                invincibleCount += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meteorite"))
        {
            MeteoriteDestoryProcess destoryProcess 
                = collision.gameObject.transform.parent.GetComponent<MeteoriteDestoryProcess>();
            destoryProcess.Dead();
            if(invincible == false && hp >0)
            {
                hp--;
            }
        }
    }
}
