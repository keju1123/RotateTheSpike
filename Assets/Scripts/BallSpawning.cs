using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameState;

public class BallSpawning : MonoBehaviour
{
    [SerializeField]
    private float timeToStartSpawning = 4f;
    [SerializeField]
    private float timeBetweenSpawns = 3f;

    private float tempTime;


    [SerializeField]
    private float TransitionTime = 1f;


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
            if (tempTime <= 0)
            {
                tempTime = timeBetweenSpawns;
                if (GameManager.score % 5 == 0)
                {
                    Invoke("SpawnBall", TransitionTime);
                }
                SpawnBall();
            }

    }

    void SpawnBall()
    {
        if(!States.havelost)
        {
            if (timeBetweenSpawns >= 1.1f) { ReduceTimeSpawn(); } else { AddTimeSpawn(); }
            Instantiate(ball, gameObject.transform.position, Quaternion.identity);
        }

    }

   void ReduceTimeSpawn()
    {
        timeBetweenSpawns += Random.Range(-0.3f, 0.2f);
    }
    void AddTimeSpawn()
    {
        timeBetweenSpawns += Random.Range(0.1f, 0.3f);
    }
}
