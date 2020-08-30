using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorData;
using UnityEngine.UI;

public class UiColorManager : MonoBehaviour
{
    [SerializeField]
    private Camera maincam;
    [SerializeField]
    private Image circle;

    [SerializeField]
    private Image panel;

    [SerializeField]
    private Animator panelAnim;
    // Start is called before the first frame update
    void Start()
    {
        int randint = Random.Range(1, ColorList.colorCollection.Count + 1);
        string index = "Color" + randint.ToString();
        PlayerPrefs.SetString("Color", index);
        maincam.backgroundColor = ColorList.colorCollection[index].camAndSpikeColor;
        circle.color = ColorList.colorCollection[index].circleColor;
        panel.color = maincam.backgroundColor;


        panelAnim.SetTrigger("OpenPanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
