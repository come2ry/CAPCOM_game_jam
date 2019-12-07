using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private MyPlanet myPlanet;
    public int playerNum;
    // Start is called before the first frame update
    private void Awake()
    {
        myPlanet = GetComponent<MyPlanet>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyCtrl();
    }

    private void KeyCtrl()
    {
        switch (playerNum)
        {
            case 1:
                if (Input.GetAxis("Horizontal") >0)
                {
                    myPlanet.PlanetRotate(Input.GetAxis("Horizontal"),1);
                    //d
                }
                else if(Input.GetAxis("Horizontal") < 0)
                {
                    myPlanet.PlanetRotate(Input.GetAxis("Horizontal"), -1);
                    //a
                }
                if (Input.GetButtonDown("Fire1"))
                {
                    myPlanet.Fire();
                }
                break;

            case 2:
                if (Input.GetAxis("Horizontal2") > 0)
                {
                    myPlanet.PlanetRotate(Input.GetAxis("Horizontal2"),1);
                }
                else if (Input.GetAxis("Horizontal2") < 0)
                {
                    myPlanet.PlanetRotate(Input.GetAxis("Horizontal2"), -1);
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    myPlanet.Fire();
                }
                break;
        }
    }
}
