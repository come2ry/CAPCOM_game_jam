using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeoPlanetsMove : MonoBehaviour
{
    public enum Size
    {
        Small,
        Midium,
        Big
    }

    public Size size;
    public float goalPos;
    public float startSpeed;
    private AllPlanetsMove allPlanetsMove;
    private bool isGoal = false;
    [SerializeField]private float[] midPoin;
    [SerializeField] private float[] speedChange; 
    private int speedLevel;
    // Start is called before the first frame update
    void Start()
    {
        allPlanetsMove = GameObject.Find("AllPlanetsMove").GetComponent<AllPlanetsMove>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMoveSpeed();
        PlanetsMove();
    }

    private void PlanetsMove()
    {
        if(transform.position.y < goalPos)
        {
            var speed = startSpeed * speedChange[speedLevel];
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, goalPos, 0);
            if(isGoal == false)
            {
                allPlanetsMove.level += 1;
                isGoal = true;
                Destroy(gameObject);
            }
        }
    }

    private void ChangeMoveSpeed()
    {
        for(int i = 0; i < midPoin.Length; i++)
        {
            if (transform.position.y >= midPoin[i] && speedLevel < i)
            {
                speedLevel += 1;
            }
        }
    }
}
