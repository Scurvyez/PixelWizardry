using HarmonyLib;
using RimWorld;
using System.Reflection;
using UnityEngine;
using Verse;

namespace PixelWizardry
{
    [HarmonyPatch(typeof(SkyManager), "CurrentSkyTarget")]
    public static class SkyManagerCurrentSkyTarget_Postfix
    {
        [HarmonyPostfix]
        public static void Postfix(ref SkyTarget __result)
        {
            bool isBlackAndWhiteMode = PlaySettingsDoPlaySettingsGlobalControls_Postfix.isBlackAndWhiteMode;
            bool isSepiaMode = PlaySettingsDoPlaySettingsGlobalControls_Postfix.isSepiaMode;
            bool isSuperSaturated = PlaySettingsDoPlaySettingsGlobalControls_Postfix.isSuperSaturatedMode;
            bool isCyberpunk = PlaySettingsDoPlaySettingsGlobalControls_Postfix.isCyberpunkMode;
            bool isRed = PlaySettingsDoPlaySettingsGlobalControls_Postfix.isRedMode;
            bool isGreen = PlaySettingsDoPlaySettingsGlobalControls_Postfix.isGreenMode;
            bool isBlue = PlaySettingsDoPlaySettingsGlobalControls_Postfix.isBlueMode;

            Map map = Find.CurrentMap;

            if (isBlackAndWhiteMode)
            {
                float saturationFactor = 0.0f;
                float lightsourceShineIntensityFactor = 0.0f;
                float glowFactor = 0.0f;

                SkyTarget b = map.weatherManager.curWeather.Worker.CurSkyTarget(map);

                b.colors.saturation *= saturationFactor;
                b.glow *= glowFactor;
                b.lightsourceShineIntensity *= lightsourceShineIntensityFactor;

                __result = SkyTarget.Lerp(map.weatherManager.lastWeather.Worker.CurSkyTarget(map), b, (float)map.weatherManager.curWeatherAge / 4000f);
            }

            if (isSepiaMode)
            {
                float sepiaR = 0.71f;
                float sepiaG = 0.58f;
                float sepiaB = 0.43f;

                float overlayR = 0.88f;
                float overlayG = 0.74f;
                float overlayB = 0.53f;

                float glowFactor = 0.1f;

                __result.colors.sky.r *= sepiaR;
                __result.colors.sky.g *= sepiaG;
                __result.colors.sky.b *= sepiaB;

                __result.colors.overlay.r *= overlayR;
                __result.colors.overlay.g *= overlayG;
                __result.colors.overlay.b *= overlayB;

                __result.glow *= glowFactor;
            }

            if (isSuperSaturated)
            {
                float saturationFactor = 1.5f;
                __result.colors.saturation *= saturationFactor;
            }

            if (isCyberpunk)
            {
                float saturationFactor = 1.5f;

                float redMultiplier = 0.5f;
                float greenMultiplier = 0.5f;
                float blueMultiplier = 0.5f;

                __result.colors.sky.r *= redMultiplier;
                __result.colors.sky.g *= greenMultiplier;
                __result.colors.sky.b *= blueMultiplier;

                __result.colors.overlay.r *= redMultiplier;
                __result.colors.overlay.g *= greenMultiplier;
                __result.colors.overlay.b *= blueMultiplier;

                __result.colors.saturation *= saturationFactor;
            }

            if (isRed)
            {
                float redMultiplier = 1.25f;
                __result.colors.sky.r *= redMultiplier;
            }

            if (isGreen)
            {
                float greenMultiplier = 1.25f;
                __result.colors.sky.g *= greenMultiplier;
            }

            if (isBlue)
            {
                float blueMultiplier = 1.25f;
                __result.colors.sky.b *= blueMultiplier;
            }
        }
    }
}
