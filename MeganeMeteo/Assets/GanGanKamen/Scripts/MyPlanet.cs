using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlanet : MonoBehaviour
{
    [SerializeField] private GameObject planet;
    [SerializeField] private float rotateSpeed;

    public GameObject meteoPrefab;
    [SerializeField] private Transform muzzle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlanetRotate(float axis)
    {
        planet.transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime * axis);
    }

    public void Fire()
    {
        GameObject planetObj = Instantiate(meteoPrefab, muzzle.position, muzzle.rotation);

    }
}
