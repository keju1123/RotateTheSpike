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
        public Color ImageColor;
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
                   ImageColor = new Color32(244,195,130,255),
                }
            },
            {
                "Color2",
                new ColorClass
                {
                    camAndSpikeColor = new Color32(27,98,191,255),
                    circleColor = new Color32(99, 161, 242,255),
                    ballColor = new Color32(244, 177, 132, 255),
                    ImageColor = new Color32(242,180,99,255),
                }
            },
            {
                "Color3",
                new ColorClass
                {
                    camAndSpikeColor = new Color32(251, 156, 164, 255),
                    circleColor = new Color32(255, 209, 209, 255),
                    ballColor = new Color32(102, 203, 254, 255),
                    ImageColor = new Color32(255,255,255, 255),
                }
            },
            {
                "Color4",
                new ColorClass
                {
                    camAndSpikeColor = new Color32(254, 189, 159, 255),
                    circleColor = new Color32(255, 219, 210, 255),
                    ballColor = new Color32(172, 96, 254, 255),
                    ImageColor = new Color32(172, 96, 254, 255),
                }
            },
            {
                "Color5",
                new ColorClass
                {
                    camAndSpikeColor = new Color32(124, 124, 124, 255),
                    circleColor = new Color32(229,217,184, 255),
                    ballColor = new Color32(143, 171, 219, 255),
                    ImageColor = new Color32(0,0,0,255),
                }
            },

        };
    }
}
