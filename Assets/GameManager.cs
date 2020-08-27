using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    public static int score = 0;

    [Header("Spikes")]
    public GameObject[] spikes;
    public int spikeAmount = 0;
    public int addSpikePer5 = 2;
    void Start()
    {
        spikes = GameObject.FindGameObjectsWithTag("Spike");

    }
    private int savedScore = -1;
    void Update()
    {
        scoreText.text = score.ToString();
        if(score % 5 == 0 && score!=savedScore)
        {
            makeNewSpike();
            savedScore = score;
        }
    }

    void makeNewSpike()
    {
        
        for(int i=0;i<spikes.Length;i++)
        {
            spikes[i].GetComponent<Animator>().Play("SpikeDissapear");
        }
        for(int i=0; i<spikeAmount+addSpikePer5;i++)
        {
            spikeAmount += addSpikePer5;
            int randnum = Random.Range(1, spikes.Length);
            spikes[randnum].GetComponent<Animator>().SetTrigger("Appear");
        }
    }
}
