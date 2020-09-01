using System;
using System.Collections.Generic;
using UnityEngine;
using ColorData;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class UiColorManager : MonoBehaviour
{
    [SerializeField]
    private Camera maincam;
    [SerializeField]
    private Image circle;

    [SerializeField]
    private Image panel;

    [SerializeField]
    private Image PlayImage;




    [Header("Buttons")]
    [SerializeField]
    private Image ShareButton;

    // Start is called before the first frame update
    void Awake()
    {
        int randint = Random.Range(1, ColorList.colorCollection.Count + 1);
        string index = "Color" + randint.ToString();
        PlayerPrefs.SetString("Color", index);
        maincam.backgroundColor = ColorList.colorCollection[index].camAndSpikeColor;
        circle.color = ColorList.colorCollection[index].circleColor;
        PlayImage.color = ColorList.colorCollection[index].ImageColor;
        ShareButton.color = PlayImage.color;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
