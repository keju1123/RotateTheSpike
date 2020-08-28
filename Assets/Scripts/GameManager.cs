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
            if(spikeAmount <= 25)
            {
                makeNewSpike();
            }
            savedScore = score;
        }
    }

    void makeNewSpike()
    {
        spikeAmount += addSpikePer5;
        for (int i = 0; i < spikeAmount + addSpikePer5; i++)
        {
            int randnum = Random.Range(1, spikes.Length);
            spikes[randnum].GetComponent<Animator>().SetTrigger("Appear");
        }
        for (int i = 0; i < spikes.Length; i++)
        {
            if(spikes[i].GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("SpikeAppear"))
            {
                spikes[i].GetComponent<Animator>().Play("SpikeDissapear");
            }
        }

    }
}
