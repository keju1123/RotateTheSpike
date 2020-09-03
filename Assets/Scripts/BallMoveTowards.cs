using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameState;
public class BallMoveTowards : MonoBehaviour
{
    public GameObject[] moveTowardsPoints;
    // Start is called before the first frame update
    [SerializeField]
    public float startSpeed;
    private int randnum;
    void Start()
    {
        
        moveTowardsPoints = GameObject.FindGameObjectsWithTag("MTPoint");
        randnum = Random.Range(1, moveTowardsPoints.Length);
        startSpeed += GameManager.score / 3;
        Debug.Log(startSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(!States.havelost)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveTowardsPoints[randnum].transform.position, startSpeed * Time.deltaTime);
        }
    }
}
