using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddGem : MonoBehaviour
{
    int defGem = 0;
    public float timeBeforeDisappear;
    public GameObject particle;

    [SerializeField]
    private TextMeshProUGUI gemText;

    public Animator CoinUI;

    private Animator GemAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        GemAnim = gameObject.GetComponentInChildren<Animator>();
        CoinUI = GameObject.FindGameObjectWithTag("CoinUI").GetComponent<Animator>();
        gemText = GameObject.FindGameObjectWithTag("GemText").GetComponent<TextMeshProUGUI>();
        gemText.text = PlayerPrefs.GetInt("Gem", defGem).ToString();
    }

    float cnt = 0f;
    // Update is called once per frame
    void Update()
    {
        cnt += Time.deltaTime;
        if(cnt >= timeBeforeDisappear)
        {
            GemAnim.SetTrigger("GemGone");
            Invoke("DestroyMe", 3f);
            cnt = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("sentuh");
        if (collision.tag == "Catcher")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("Gem", PlayerPrefs.GetInt("Gem", defGem) + 1);

            DestroyMe();
               
            if(CoinUI.GetCurrentAnimatorClipInfo(0)[0].clip.name == "CoinIdle")
            {
                CoinUI.SetTrigger("ShowCoin");
            }

            gemText.text = PlayerPrefs.GetInt("Gem", defGem).ToString();
        }
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
