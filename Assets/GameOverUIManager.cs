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
    private Camera mainCamera;
    [SerializeField]
    private Image panelImage;
    [SerializeField]
    private Animator panelAnim;

    string index;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI highScoreText;
    [SerializeField]
    private GameObject ConfettiParticle;
    // Start is called before the first frame update

    public int HighScore;
    private void Awake()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        index = PlayerPrefs.GetString("Color", "Color1");
        panelImage.color = ColorList.colorCollection[index].camAndSpikeColor;
    }

    private void Start()
    {
        scoreText.text = Scores.currScore.ToString();
        if(Scores.currScore > HighScore)
        {
            HighScore = Scores.currScore;
            highScoreText.text = HighScore.ToString();
            PlayerPrefs.SetInt("HighScore", Scores.currScore);
            Vector3 confpos = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height/2,0)); 
            Instantiate(ConfettiParticle,confpos, Quaternion.Euler(-97, 93, -90));
            Vector3 confpos2 = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height/2,0)); 
            Instantiate(ConfettiParticle,confpos2, Quaternion.Euler(-80, 93, -90));
        }
        else
        {
            highScoreText.text = HighScore.ToString();
        }
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

        new NativeShare().AddFile(filePath).SetSubject("Play this game!")
            .SetText("Come on!, Beat my score on this game!")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();
    }
}
