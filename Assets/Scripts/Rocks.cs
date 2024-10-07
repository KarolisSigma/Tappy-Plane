using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    private float speed;
    [SerializeField] GameObject rocks;
    private List<Transform> transforms = new List<Transform>();
   // private List<GameObject> objects = new List<GameObject>();
    private Vector3 spawnPos;
    private int count = 2;
    void Start()
    {
        speed=3f;
        spawnPos = new Vector3(10,0,0);
        GameObject rock1 = Instantiate(rocks, spawnPos+Vector3.up*Random.Range(-2, 3), Quaternion.identity);
        GameObject rock2 = Instantiate(rocks, spawnPos+new Vector3(10,0,0)+Vector3.up*Random.Range(-2, 3), Quaternion.identity);

        //objects.Add(rock1);
        transforms.Add(rock1.transform);
       // objects.Add(rock2);
        transforms.Add(rock2.transform);
    }

    
    void Update()
    {
        for (int i = 0; i < count; i++)
        {
            if(transforms[i].position.x < -10){
                transforms[i].position = spawnPos+Vector3.up*Random.Range(-2, 3);
                speed+=0.1f;
            }
            transforms[i].position += Vector3.left*speed*Time.deltaTime;
        }
    }
}
