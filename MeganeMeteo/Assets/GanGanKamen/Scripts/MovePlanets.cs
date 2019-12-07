using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlanets : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private bool isRotate;
    [SerializeField] [Range(-1, 1)] private int direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    private void Moving()
    {
        if (isRotate)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime * direction);
        }
    }
}
