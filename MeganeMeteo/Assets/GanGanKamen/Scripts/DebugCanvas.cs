using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugCanvas : MonoBehaviour
{
    [SerializeField] private MyPlanet[] planets;
    [SerializeField] private Text playerA_bulletNum;
    [SerializeField] private Text playerB_bulletNum;
    [SerializeField] private Slider playerA_bulletCharge;
    [SerializeField] private Slider playerB_bulletCharge;
    [SerializeField] private Text playerA_hp;
    [SerializeField] private Text playerB_hp;
    // Start is called before the first frame update
    void Start()
    {
        playerA_bulletCharge.maxValue = planets[0].chargeTime;
        playerB_bulletCharge.maxValue = planets[1].chargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        playerA_bulletNum.text = "Player1残弾数" + planets[0].bulletNum.ToString();
        playerB_bulletNum.text = "Player2残弾数" + planets[1].bulletNum.ToString();
        playerA_bulletCharge.value = planets[0].chargeCount;
        playerB_bulletCharge.value = planets[1].chargeCount;
        playerA_hp.text = "Player1HP:" + planets[0].hp.ToString();
        playerB_hp.text = "Player2HP:" + planets[1].hp.ToString();
    }
}
