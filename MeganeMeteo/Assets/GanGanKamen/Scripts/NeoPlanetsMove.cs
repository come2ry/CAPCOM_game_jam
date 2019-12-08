using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeoPlanetsMove : MonoBehaviour
{
    public enum Difficulty
    {
        Esay,
        Medium,
        Hard
    }

    public Difficulty difficulty;
    public float goalPos;
    public float startSpeed;
    public float decelerationSpeed;
    private float realSpeed;
    private AllPlanetsMove allPlanetsMove;
    private bool isGoal = false;
    [SerializeField]private Vector2 decelerationRange;
    [SerializeField] private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        allPlanetsMove = GameObject.Find("AllPlanetsMove").GetComponent<AllPlanetsMove>();
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {

        ChangeSpeed();
        PlanetsMove();
    }

    private void ChangeSpeed()
    {
        if (transform.position.y >= decelerationRange.x && transform.position.y <= decelerationRange.y)
        {
            realSpeed = decelerationSpeed;
        }
        else
        {
            realSpeed = startSpeed;
        }

    }

    private void PlanetsMove()
    {
        if(transform.position.y < goalPos)
        {
            transform.Translate(0, realSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, goalPos, 0);
            if(isGoal == false)
            {
                isGoal = true;
                allPlanetsMove.CreatPlanets();
                Destroy(gameObject);
            }
        }
    }
}
