using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScoreData;
using UnityEngine.SceneManagement;
using GameState;


public class CollisionBall : MonoBehaviour
{
    public GemSpawning gemSpawning;
    public GameObject ExplodeSmallParticle;
    public PhysicsMaterial2D bouncy;
    [SerializeField]
    private Animator panelAnim;
    private BallMoveTowards ballstatus;
    private Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = gameObject.GetComponent<Rigidbody2D>();
        gemSpawning = GameObject.FindGameObjectWithTag("Spawner").GetComponent<GemSpawning>();
        ballstatus = gameObject.GetComponent<BallMoveTowards>();
        panelAnim = GameObject.FindGameObjectWithTag("panel").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals("Circle"))
        {
            Instantiate(ExplodeSmallParticle, transform.position, Quaternion.identity);
            if (!States.havelost)
            {
                GameManager.score++;
                gemSpawning.SpawnGem();
                DestroyMe();
            }
        }
        if (collision.collider.tag.Equals("Spike") && !States.havelost)
        {
            States.havelost = true;
            Scores.currScore = GameManager.score;
            myRB.gravityScale = 1f;
            myRB.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
            myRB.sharedMaterial = bouncy;

            StartCoroutine(LoseGame());
        }
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }

    IEnumerator LoseGame()
    {
        
        yield return new WaitForSecondsRealtime(2f);
        panelAnim.SetTrigger("ClosePanel");
        yield return new WaitForSecondsRealtime(0.5f);
        GameManager.score = 0;
        SceneManager.LoadScene("GameOver");
    }
}
