using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawning : MonoBehaviour
{
    public GameObject[] spawnPoints;

    public float SpawnPercentage = 25;
    public GameObject gem;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("MTPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnGem()
    {
        int randint = Random.Range(1, 101);
        int randindex = Random.Range(1, spawnPoints.Length);
        if(randint < SpawnPercentage)
        {
            Instantiate(gem, spawnPoints[randindex].transform.position, Quaternion.identity);
        }
    }
}
