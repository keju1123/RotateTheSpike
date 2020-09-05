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
    [SerializeField]
    private Image ShareImage;
    [SerializeField]
    private Image ShopButton;
    [SerializeField]
    private Image ShopImage;

    string index;

    // Start is called before the first frame update
    void Awake()
    {
        int randint = Random.Range(1, ColorList.colorCollection.Count + 1);
        index = "Color" + randint.ToString();
        maincam.backgroundColor = ColorList.colorCollection[index].camAndSpikeColor;
        circle.color = ColorList.colorCollection[index].circleColor;
        PlayImage.color = ColorList.colorCollection[index].ImageColor;
        ShareButton.color = PlayImage.color;
        ShopButton.color = PlayImage.color;

        byte Y = (byte)(0.2126 * 255 * PlayImage.color.r + 0.7152 * 255 * PlayImage.color.g + 0.0722 * 255 * PlayImage.color.b);
        if(Y <128)
        {
            ShareImage.color = Color.white;
            ShopImage.color = Color.white;
        }
        else
        {
            ShareImage.color = Color.black;
            ShopImage.color = Color.black;
        }

    }

    private void Start()
    {
        PlayerPrefs.SetString("Color", index);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
