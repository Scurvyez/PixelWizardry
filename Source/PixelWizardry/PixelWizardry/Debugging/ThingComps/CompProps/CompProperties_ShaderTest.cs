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
        public Color color1 = Color.red;
        public Color color2 = Color.green;
        public Color color3 = Color.blue;
        public Color color4 = Color.yellow;
        public Color color5 = Color.cyan;
        public Color color6 = Color.magenta;
    }
}