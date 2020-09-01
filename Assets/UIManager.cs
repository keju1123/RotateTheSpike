using System.Collections;
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
    private void Start()
    {
        index = PlayerPrefs.GetString("Color", "Color1");
        panelImage.color = ColorList.colorCollection[index].camAndSpikeColor;
    }
    public void onPlayButton()
    {
        index = PlayerPrefs.GetString("Color", "Color1");
        StartCoroutine(PlayButton());
    }

    IEnumerator PlayButton()
    {
        panelAnim.SetTrigger("ClosePanel");
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("Endless");
    }
}
