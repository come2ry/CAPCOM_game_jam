using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlanetsMove : MonoBehaviour
{
    //public Vector3[] startPosition;
    //public float[] goalPosition;
    public List<GameObject> smallPlanets;
    public List<GameObject> midPlanets;
    public List<GameObject> hardPlanets;

    public NeoPlanetsMove.Difficulty difficulty;
    private int planetsNum;
    // Start is called before the first frame update
    void Start()
    {
        CreatPlanets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatPlanets()
    {
        switch (difficulty)
        {
            case NeoPlanetsMove.Difficulty.Esay:
                GameObject planetsObj = Instantiate(smallPlanets[planetsNum], Vector3.zero, Quaternion.identity);
                NeoPlanetsMove planetsMove = planetsObj.GetComponent<NeoPlanetsMove>();
                planetsNum++;
                if(planetsNum >= smallPlanets.Count)
                {
                    planetsNum = 0;
                    difficulty = NeoPlanetsMove.Difficulty.Medium;
                }
                break;
            case NeoPlanetsMove.Difficulty.Medium:
                GameObject planetsObj1 = Instantiate(midPlanets[planetsNum], Vector3.zero, Quaternion.identity);
                //NeoPlanetsMove planetsMove1 = planetsObj1.GetComponent<NeoPlanetsMove>();
                planetsNum++;
                if (planetsNum >= midPlanets.Count)
                {
                    planetsNum = 0;
                    difficulty = NeoPlanetsMove.Difficulty.Hard;
                }
                break;
            case NeoPlanetsMove.Difficulty.Hard:
                GameObject planetsObj2 = Instantiate(hardPlanets[planetsNum], Vector3.zero, Quaternion.identity);
                //NeoPlanetsMove planetsMove2 = planetsObj1.GetComponent<NeoPlanetsMove>();
                planetsNum++;
                if (planetsNum >= hardPlanets.Count)
                {
                    planetsNum = 0;
                }
                break;
        }
    }
}
