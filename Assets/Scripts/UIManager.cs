﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ColorData;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image panelImage;
    [SerializeField]
    private Animator panelAnim;

    string index;
    private void Awake()
    {
        index = PlayerPrefs.GetString("Color", "Color1");
        panelImage.color = ColorList.colorCollection[index].camAndSpikeColor;
    }
    public void onPlayButton()
    {
        index = PlayerPrefs.GetString("Color", "Color1");
        panelImage.color = ColorList.colorCollection[index].camAndSpikeColor;
        StartCoroutine(PlayButton());
    }

    public void onShareButton()
    {
        StartCoroutine(ShareTheGame());
    }
    public void onShopButton()
    {
        SSTools.ShowMessage("Coming soon", SSTools.Position.bottom, SSTools.Time.twoSecond);
    }
    IEnumerator ShareTheGame()
    {
        yield return new WaitForEndOfFrame();
        new NativeShare().SetSubject("Compete with Me!").SetText("Play this game and see if you can beat my highscore! (Link Here)").Share();
    }

    IEnumerator PlayButton()
    {
        panelAnim.SetTrigger("ClosePanel");
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("Endless");
    }
}
