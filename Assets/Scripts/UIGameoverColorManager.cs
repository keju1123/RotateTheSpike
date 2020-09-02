using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ColorData;

public class UIGameoverColorManager : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Image circle;
    [SerializeField]
    private Image ShareCircle;
    [SerializeField]
    private Image replayImage;
    [SerializeField]
    private Image ShareImage;
    [SerializeField]
    private SpriteRenderer MiddleCircle;
    private void Awake()
    {
        string index = PlayerPrefs.GetString("Color", "Color1");
        mainCamera.backgroundColor = ColorList.colorCollection[index].camAndSpikeColor;
        circle.color = ColorList.colorCollection[index].ImageColor;
        ShareCircle.color = circle.color;
        MiddleCircle.color = ColorList.colorCollection[index].circleColor;
        byte Y = (byte)(0.2126 * 255 * circle.color.r + 0.7152 * 255 * circle.color.g + 0.0722 * 255 * circle.color.b);
        if (Y < 128)
        {
            replayImage.color = Color.white;
            ShareImage.color = Color.white;
        }
        else
        {
            replayImage.color = Color.black;
            ShareImage.color = Color.black;
        }

    }
}
