using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawning : MonoBehaviour
{
    [SerializeField]
    private float timeToStartSpawning = 1.5f;
    [SerializeField]
    private float timeBetweenSpawns = 1f;

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
        }
    }

    void SpawnBall()
    {
        timeBetweenSpawns += Random.Range(-0.4f, 0.2f);
        Instantiate(ball, gameObject.transform.position, Quaternion.identity);
    }
}
