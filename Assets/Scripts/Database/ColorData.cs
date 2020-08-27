using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorData
{
    public class ColorClass
    {
        public Color camAndSpikeColor;
        public Color circleColor;
        public Color ballColor;
    }

    public static class ColorList
    {
        public static Dictionary<string, ColorClass> colorCollection = new Dictionary<string, ColorClass>()
        {
            {
                "Color1",
                new ColorClass
                {
                   camAndSpikeColor = new Color32(157, 195, 231, 255),
                   circleColor = new Color32(222, 234, 246, 255),
                   ballColor = new Color32(244, 177, 132, 255),
                }
            },
            {
                "Color2",
                new ColorClass
                {

                }
            },
        };
    }
}
