using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : MonoBehaviour
{
    public MyPlanet myPlanet;

    [SerializeField] private Text hpText;
    [SerializeField] private Slider coolDown;

    [SerializeField] private Text bulletNum;
    [SerializeField] private Slider bulletCharge;
    // Start is called before the first frame update
    private void Awake()
    {
        coolDown.maxValue = myPlanet.coolDownTime;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIChange();
        if (myPlanet.hasBulletNum)
        {
            BulletUISet();
            BulletNumCharge();
        }
    }

    private void UIChange()
    {
        hpText.text = "HP" + myPlanet.hp.ToString();
        coolDown.value = coolDown.maxValue - myPlanet.coolDownCount;
    }

    private void BulletUISet()
    {
        bulletCharge.maxValue = myPlanet.chargeTime;
    }

    private void BulletNumCharge()
    {
        bulletNum.text = " 残弾数" + myPlanet.bulletNum.ToString();
        bulletCharge.value = myPlanet.chargeCount;
    }
}
