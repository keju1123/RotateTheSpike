using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI gemText;
    private void Start()
    {
        gemText.text = PlayerPrefs.GetInt("Gem", 0).ToString();
    }
}
