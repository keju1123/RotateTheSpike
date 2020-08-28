using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveTowards : MonoBehaviour
{
    public GameObject[] moveTowardsPoints;
    // Start is called before the first frame update
    private float speed;
    public float minSpeed = 10f;
    public float maxSpeed = 30f;
    private int randnum;
    void Start()
    {
        moveTowardsPoints = GameObject.FindGameObjectsWithTag("MTPoint");
        randnum = Random.Range(1, moveTowardsPoints.Length);
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveTowardsPoints[randnum].transform.position, speed * Time.deltaTime);
    }
}
