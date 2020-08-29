using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddGem : MonoBehaviour
{
    int defGem = 0;
    public GameObject particle;

    [SerializeField]
    private TextMeshProUGUI gemText;
    // Start is called before the first frame update
    void Start()
    {
        gemText = GameObject.FindGameObjectWithTag("GemText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("sentuh");
        if (collision.tag == "Catcher")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("Gem", PlayerPrefs.GetInt("Gem", defGem) + 1);
            Destroy(gameObject);

            gemText.text = PlayerPrefs.GetInt("Gem", defGem).ToString();
        }
    }
}
