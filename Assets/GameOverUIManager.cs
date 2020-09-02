using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorData;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField]
    private Image panelImage;
    [SerializeField]
    private Animator panelAnim;

    string index;


    // Start is called before the first frame update
    private void Awake()
    {
        index = PlayerPrefs.GetString("Color", "Color1");
        panelImage.color = ColorList.colorCollection[index].camAndSpikeColor;
    }

    public void onMainButton()
    {
        StartCoroutine(BackToMain());
    }

    IEnumerator BackToMain()
    {
        panelAnim.SetTrigger("ClosePanel");
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
