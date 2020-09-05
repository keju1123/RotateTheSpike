using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorData;
using GameState;

public class ColorManager : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private SpriteRenderer circle;
    [SerializeField]
    private GameObject[] spikeObj;
    [SerializeField]
    private SpriteRenderer ball;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private TrailRenderer ballTrail;
    [SerializeField]
    private SpriteRenderer catcher1;
    [SerializeField]
    private SpriteRenderer catcher2;
    [SerializeField]
    private ParticleSystem ballexplodeSmall;
    //private GameObject ball;


    // Start is called before the first frame update
    void Awake()
    {
        spikeObj = GameObject.FindGameObjectsWithTag("spikeobj");
        string index = PlayerPrefs.GetString("Color", "Color1");
        ParticleSystem.MainModule settings = particle.main;
        ParticleSystem.MainModule expSmall = ballexplodeSmall.main;
        mainCamera.backgroundColor = ColorList.colorCollection[index].camAndSpikeColor;

        for(int i=0;i<spikeObj.Length;i++)
        {
            spikeObj[i].GetComponentInChildren<SpriteRenderer>().color = mainCamera.backgroundColor;
        }


        circle.color = ColorList.colorCollection[index].circleColor;
        ball.color = ColorList.colorCollection[index].ballColor;
        expSmall.startColor = ball.color;
        settings.startColor = ball.color;
        ballTrail.startColor = ball.color;
        ballTrail.endColor = new Color32(255, 255, 255, 128);
        catcher1.color = circle.color;
        catcher2.color = circle.color;
    }


}
