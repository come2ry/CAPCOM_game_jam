using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlanetsMove : MonoBehaviour
{
    public Vector3[] startPosition;
    public float[] goalPosition;
    public GameObject smallPlanets;
    public GameObject midPlanets;
    public GameObject bigPlanets;

    public int level;
    private int preLevel;
    // Start is called before the first frame update
    void Start()
    {
        preLevel = level;
        GameObject planetsObj = Instantiate(smallPlanets, startPosition[0], Quaternion.identity);
        NeoPlanetsMove planetsMove = planetsObj.GetComponent<NeoPlanetsMove>();
        planetsMove.goalPos = goalPosition[0];
    }

    // Update is called once per frame
    void Update()
    {
        LevelUp();
    }

    private void LevelUp()
    {
        if(preLevel != level)
        {
            switch (level)
            {
                case 1:
                    GameObject planetsObj = Instantiate(midPlanets, startPosition[1], Quaternion.identity);
                    NeoPlanetsMove planetsMove = planetsObj.GetComponent<NeoPlanetsMove>();
                    planetsMove.goalPos = goalPosition[1];
                    break;
                default:
                    GameObject planetsObj1 = Instantiate(bigPlanets, startPosition[2], Quaternion.identity);
                    NeoPlanetsMove planetsMove1 = planetsObj1.GetComponent<NeoPlanetsMove>();
                    planetsMove1.goalPos = goalPosition[2];
                    break;
            }
            preLevel = level;
        }
    }
}
