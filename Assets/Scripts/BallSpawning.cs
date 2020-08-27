using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawning : MonoBehaviour
{
    [SerializeField]
    private float timeToStartSpawning = 4f;
    [SerializeField]
    private float timeBetweenSpawns = 3f;

    private float tempTime;


    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        tempTime = timeToStartSpawning;
    }

    // Update is called once per frame
    void Update()
    {
        tempTime -= Time.deltaTime;
        if(tempTime <= 0)
        {
            tempTime = timeBetweenSpawns;
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        if (timeBetweenSpawns > 1f) { ReduceTimeSpawn(); }
        Instantiate(ball, gameObject.transform.position, Quaternion.identity);
    }

   void ReduceTimeSpawn()
    {
        timeBetweenSpawns += Random.Range(-0.4f, 0.2f);
    }
}
