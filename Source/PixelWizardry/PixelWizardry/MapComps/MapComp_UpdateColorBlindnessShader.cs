using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class MapComp_UpdateColorBlindnessShader : MapComponent
    {
        FullScreenEffects fullScreenEffects = FullScreenEffects.instance;

        public MapComp_UpdateColorBlindnessShader(Map map) : base(map) { }

        public override void MapComponentTick()
        {
            base.MapComponentTick();

            bool Protanopia = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Protanopia;
            bool Protanomaly = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Protanomaly;
            bool Deuteranopia = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Deuteranopia;
            bool Deuteranomaly = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Deuteranomaly;
            bool Tritanopia = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Tritanopia;
            bool Tritanomaly = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Tritanomaly;
            bool Achromatopsia = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Achromatopsia;
            bool Achromatomaly = PlaySettingsDoPlaySettingsGlobalControls_Postfix.Achromatomaly;

            if (PWModSettings.IntensityFactor > 0)
            {
                fullScreenEffects.material.SetFloat("_IntensityFactor", PWModSettings.IntensityFactor);
            }

            if (Protanopia)
            {
                ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Protanopia);
            }
            else if (Protanomaly)
            {
                ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Protanomaly);
            }
            else if (Deuteranopia)
            {
                ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Deuteranopia);
            }
            else if (Deuteranomaly)
            {
                ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Deuteranomaly);
            }
            else if (Tritanopia)
            {
                ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Tritanopia);
            }
            else if (Tritanomaly)
            {
                ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Tritanomaly);
            }
            else if (Achromatopsia)
            {
                ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Achromatopsia);
            }
            else if (Achromatomaly)
            {
                ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Achromatomaly);
            }
            else
            {
                ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.material, ColorBlindnessUtility.ColorBlindMode.Normal);
            }
        }
    }
}
