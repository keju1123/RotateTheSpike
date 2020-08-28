using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionBall : MonoBehaviour
{
    public GemSpawning gemSpawning;
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
        }
        if (collision.collider.tag.Equals("Spike"))
        {
            GameManager.score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
