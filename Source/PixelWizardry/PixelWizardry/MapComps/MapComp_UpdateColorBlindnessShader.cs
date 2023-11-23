using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class MapComp_UpdateColorBlindnessShader :MapComponent
    {
        bool Protanopia = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Protanopia;
        bool Protanomaly = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Protanomaly;
        bool Deuteranopia = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Deuteranopia;
        bool Deuteranomaly = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Deuteranomaly;
        bool Tritanopia = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Tritanopia;
        bool Tritanomaly = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Tritanomaly;
        bool Achromatopsia = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Achromatopsia;
        bool Achromatomaly = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Achromatomaly;

        private FullScreenEffects FullScreenEffects = new FullScreenEffects();

        public MapComp_UpdateColorBlindnessShader(Map map) : base(map) { }

        public override void MapComponentTick()
        {
            base.MapComponentTick();

            if (FullScreenEffects.material != null)
            {
                if (Protanopia)
                {
                    Log.Message("Protanopia active");
                    ColorBlindnessUtility.SetColorBlindnessProperties(FullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Protanopia);
                }
                else if (Protanomaly)
                {
                    Log.Message("Protanomaly active");
                    ColorBlindnessUtility.SetColorBlindnessProperties(FullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Protanomaly);
                }
                else if (Deuteranopia)
                {
                    Log.Message("Deuteranopia active");
                    ColorBlindnessUtility.SetColorBlindnessProperties(FullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Deuteranopia);
                }
                else if (Deuteranomaly)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(FullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Deuteranomaly);
                }
                else if (Tritanopia)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(FullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Tritanopia);
                }
                else if (Tritanomaly)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(FullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Tritanomaly);
                }
                else if (Achromatopsia)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(FullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Achromatopsia);
                }
                else if (Achromatomaly)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(FullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Achromatomaly);
                }
                else
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(FullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Normal);
                }
            }
        }
    }
}
