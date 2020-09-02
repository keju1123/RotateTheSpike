using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScoreData;
using UnityEngine.SceneManagement;

public class CollisionBall : MonoBehaviour
{
    public GemSpawning gemSpawning;
    public GameObject ExplodeSmallParticle;
    // Start is called before the first frame update
    void Start()
    {
        gemSpawning = GameObject.FindGameObjectWithTag("Spawner").GetComponent<GemSpawning>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals("Circle"))
        {
            GameManager.score++;
            gemSpawning.SpawnGem();
            DestroyMe();
            Instantiate(ExplodeSmallParticle, transform.position, Quaternion.identity);
        }
        if (collision.collider.tag.Equals("Spike"))
        {
            Scores.currScore = GameManager.score;
            GameManager.score = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
