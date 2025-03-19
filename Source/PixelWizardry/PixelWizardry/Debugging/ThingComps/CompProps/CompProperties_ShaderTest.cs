using UnityEngine;
using Verse;

namespace PixelWizardry.CompProps
{
    public class CompProperties_ShaderTest : CompProperties
    {
        public CompProperties_ShaderTest() => compClass = typeof(CompShaderTest);
        
        public ThingDef moteDef = null;
        public Color moteColor = Color.clear;
        
        public float blendStrength = 0f;
        public bool oscillateColors;
        public Color color1 = Color.red;
        public Color color2 = Color.green;
        public Color color3 = Color.blue;
        public Color color4 = Color.yellow;
        public Color color5 = Color.cyan;
        public Color color6 = Color.magenta;
        public Color color1Alt = Color.red;
        public Color color2Alt = Color.green;
        public Color color3Alt = Color.blue;
        public Color color4Alt = Color.yellow;
        public Color color5Alt = Color.cyan;
        public Color color6Alt = Color.magenta;
        
        public Vector4 GetColor(int index)
        {
            return index switch
            {
                0 => color1,
                1 => color2,
                2 => color3,
                3 => color4,
                4 => color5,
                5 => color6,
                _ => color1 // fallback
            };
        }
    }
}