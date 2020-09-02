using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorData;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ScoreData;
using TMPro;
using System.IO;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField]
    private Image panelImage;
    [SerializeField]
    private Animator panelAnim;

    string index;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    private void Awake()
    {
        index = PlayerPrefs.GetString("Color", "Color1");
        panelImage.color = ColorList.colorCollection[index].camAndSpikeColor;
    }

    private void Start()
    {
        scoreText.text = Scores.currScore.ToString();
    }
    public void onMainButton()
    {
        StartCoroutine(BackToMain());
    }

    public void onShareButton()
    {
        StartCoroutine(TakeScreenshotAndShare());
    }

    IEnumerator BackToMain()
    {
        panelAnim.SetTrigger("ClosePanel");
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("MainMenu");
    }
    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        Destroy(ss);

        new NativeShare().AddFile(filePath)
            .SetText("Come on!, Beat my score on this game!")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();
    }
}
