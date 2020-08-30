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
        string index = PlayerPrefs.GetString("Color", "Color1");
        ParticleSystem.MainModule settings = particle.main;
        spike = spikeObj.GetComponentInChildren<SpriteRenderer>();
        mainCamera.backgroundColor = ColorList.colorCollection[index].camAndSpikeColor;
        circle.color = ColorList.colorCollection[index].circleColor;
        spike.color = ColorList.colorCollection[index].camAndSpikeColor;
        ball.color = ColorList.colorCollection[index].ballColor;
        settings.startColor = ball.color;
        ballTrail.startColor = ball.color;
        ballTrail.endColor = new Color32(255, 255, 255, 128);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
