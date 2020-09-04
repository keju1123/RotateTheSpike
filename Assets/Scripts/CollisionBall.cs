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
    [SerializeField]
    private Animator panelAnim;
    private BallMoveTowards ballstatus;
    private Rigidbody2D myRB;
    public float addtorqueamount;
    public PhysicsMaterial2D bouncy;
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
        //myRB.sharedMaterial.bounciness = 2f;
        myRB.AddTorque(addtorqueamount);
        myRB.AddForce(new Vector2(0,160), ForceMode2D.Impulse);
        yield return new WaitForSecondsRealtime(2f);
        panelAnim.SetTrigger("ClosePanel");
        yield return new WaitForSecondsRealtime(0.5f);
        GameManager.score = 0;
        SceneManager.LoadScene("GameOver");
    }
}
