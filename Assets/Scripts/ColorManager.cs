using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorData;

public class ColorManager : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private SpriteRenderer circle;
    private SpriteRenderer spike;
    [SerializeField]
    private GameObject spikeObj;
    [SerializeField]
    private SpriteRenderer ball;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private TrailRenderer ballTrail;
    //private GameObject ball;


    // Start is called before the first frame update
    void Awake()
    {
        ParticleSystem.MainModule settings = particle.main;
        spike = spikeObj.GetComponentInChildren<SpriteRenderer>();
        mainCamera.backgroundColor = ColorList.colorCollection["Color1"].camAndSpikeColor;
        circle.color = ColorList.colorCollection["Color1"].circleColor;
        spike.color = ColorList.colorCollection["Color1"].camAndSpikeColor;
        ball.color = ColorList.colorCollection["Color1"].ballColor;
        settings.startColor = ball.color;
        ballTrail.startColor = ball.color;
        ballTrail.endColor = new Color32(255, 255, 255, 128);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
