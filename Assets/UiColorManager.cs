using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorData;

public class UiColorManager : MonoBehaviour
{
    [SerializeField]
    private Camera maincam;
    // Start is called before the first frame update
    void Start()
    {
        int randint = Random.Range(1, ColorList.colorCollection.Count + 1);
        string index = "Color" + randint.ToString();
        PlayerPrefs.SetString("Color", index);
        maincam.backgroundColor = ColorList.colorCollection[index].camAndSpikeColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
