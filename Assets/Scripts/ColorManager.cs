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
    //private GameObject ball;


    // Start is called before the first frame update
    void Awake()
    {
        ParticleSystem.MainModule settings = particle.main;
        settings.startColor = ColorList.colorCollection["Color1"].ballColor;
        spike = spikeObj.GetComponentInChildren<SpriteRenderer>();
        mainCamera.backgroundColor = ColorList.colorCollection["Color1"].camAndSpikeColor;
        circle.color = ColorList.colorCollection["Color1"].circleColor;
        spike.color = ColorList.colorCollection["Color1"].camAndSpikeColor;
        ball.color = ColorList.colorCollection["Color1"].ballColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
