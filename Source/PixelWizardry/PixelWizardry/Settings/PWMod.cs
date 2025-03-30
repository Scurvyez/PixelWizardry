using System;
using UnityEngine;
using Verse;
using System.Runtime.InteropServices;
using System.IO;
using HarmonyLib;

namespace PixelWizardry
{
    public class PWMod : Mod
    {
        public static PWMod PW_Mod;
        private readonly PWSettings _settings;
        private float _halfWidth;
        private Vector2 _leftScrollPos = Vector2.zero;
        private const int _sliderMinInt = 0;
        private const int _sliderMaxInt = 100;
        
        private static Color CategoryTextColor => PWLog.MessageMsgCol;
        public override string SettingsCategory() => "PW_ModName".Translate();
        
        public PWMod(ModContentPack content) : base(content)
        {
            PW_Mod = this;
            _settings = GetSettings<PWSettings>();
            
            Harmony harmony = new("rimworld.scurvyez.pixelwizardrymod");
            // this patch needs to happen at this point -_-
            harmony.Patch(original: AccessTools.PropertyGetter(typeof(ShaderTypeDef), nameof(ShaderTypeDef.Shader)),
                prefix: new HarmonyMethod(typeof(PWMod),
                    nameof(ShaderFromAssetBundle)));
            harmony.PatchAll();
        }
        
        public static void ShaderFromAssetBundle(ShaderTypeDef __instance, ref Shader ___shaderInt)
        {
            if (__instance is not PWShaderTypeDef) return;
            ___shaderInt = PWContentDatabase.PWBundle.LoadAsset<Shader>(__instance.shaderPath);
            
            if (___shaderInt is null)
            {
                PWLog.Error($"[PWMod] Failed to load Shader from path <text>\"{__instance.shaderPath}\"</text>");
            }
        }
        
        public AssetBundle MainBundle
        {
            get
            {
                string text = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "StandaloneOSX"
                    : RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "StandaloneWindows64"
                    : RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "StandaloneLinux64"
                    : throw new PlatformNotSupportedException("Unsupported Platform");
                
                string bundlePath = Path.Combine(Content.RootDir, 
                    @"Materials\Bundles\" + text + "\\pixelwizardrybundle");
                //PWLog.Message("Bundle Path: " + bundlePath);
                
                AssetBundle bundle = AssetBundle.LoadFromFile(bundlePath);
                
                if (bundle == null)
                {
                    PWLog.Error("[PWMod] Failed to load bundle at path: " + bundlePath);
                }
                
                // foreach (string allAssetName in bundle.GetAllAssetNames())
                // {
                //     PWLog.Message($"[{allAssetName}]");
                // }
                return bundle;
            }
        }
        
        public override void DoSettingsWindowContents(Rect inRect)
        {
            _halfWidth = (inRect.width - 30f) / 2;
            LeftSideScrollViewHandler(new Rect(inRect.x, inRect.y, _halfWidth, inRect.height));
        }
        
        private void LeftSideScrollViewHandler(Rect inRect)
        {
            Listing_Standard listLeft = new();
            Rect viewRectLeft = new(inRect.x, inRect.y, inRect.width, inRect.height);
            Rect vROffsetLeft = new(0, 0, inRect.width - 20, inRect.height);
            
            Widgets.BeginScrollView(viewRectLeft, ref _leftScrollPos, vROffsetLeft);
            listLeft.Begin(vROffsetLeft);
            
            #region HSV_Settings_Main
            listLeft.Label("HSV Settings".Colorize(CategoryTextColor));
            listLeft.CheckboxLabeled("PW_EnableHSVAdjustment".Translate(), 
                ref _settings._EnableHSVAdjustment, 
                "PW_EnableHSVAdjustmentDesc".Translate());
            listLeft.Gap(3.0f);
            #endregion
            
            #region HSV_Settings_Hue
            Color hueColor = Color.HSVToRGB(_settings._HAmount, 1f, 1f);
            listLeft.Label(label: $"{"PW_HAmount".Translate()}" +
                                  $" ({hueColor.r:F2}, {hueColor.g:F2}, {hueColor.b:F2})", 
                tooltip: "PW_HAmountDesc".Translate());
            
            int hAmountInt = Mathf.RoundToInt(_settings._HAmount * _sliderMaxInt);
            hAmountInt = Mathf.RoundToInt(listLeft.Slider(hAmountInt, _sliderMinInt, _sliderMaxInt));
            _settings._HAmount = hAmountInt / (float)_sliderMaxInt; // normalize to [0.0, 1.0]
            
            Rect hueGradientRect = listLeft.GetRect(12f);
            Widgets.DrawTextureFitted(
                hueGradientRect,
                SettingsHelper.GenerateHueGradient((int)vROffsetLeft.width - 12, 12), 
                1.0f);
            listLeft.Gap(9.0f);
            #endregion
            
            #region HSV_Settings_Saturation
            listLeft.Label(label: $"{"PW_SAmount".Translate()} " +
                                  $"({(_settings._SAmount * 100):F0}%)", 
                tooltip: "PW_SAmountDesc".Translate());
            
            int sAmountInt = Mathf.RoundToInt((_settings._SAmount - 0f) / 2f * _sliderMaxInt);
            sAmountInt = Mathf.RoundToInt(listLeft.Slider(sAmountInt, _sliderMinInt, _sliderMaxInt));
            _settings._SAmount = Mathf.Lerp(0f, 2f, sAmountInt / (float)_sliderMaxInt);
            
            Rect satGradientRect = listLeft.GetRect(12f);
            Widgets.DrawTextureFitted(
                satGradientRect,
                SettingsHelper.GenerateSaturationGradient((int)vROffsetLeft.width - 12, 12, _settings._HAmount), 
                1.0f);
            listLeft.Gap(9.0f);
            #endregion
            
            #region HSV_Settings_Value
            listLeft.Label(label: $"{"PW_VAmount".Translate()} " +
                                  $"({(_settings._VAmount * 100):F0}%)", 
                tooltip: "PW_VAmountDesc".Translate());
            
            int vAmountInt = Mathf.RoundToInt((_settings._VAmount - 0f) / 2f * _sliderMaxInt);
            vAmountInt = Mathf.RoundToInt(listLeft.Slider(vAmountInt, _sliderMinInt, _sliderMaxInt));
            _settings._VAmount = Mathf.Lerp(0f, 2f, vAmountInt / (float)_sliderMaxInt);
            
            Rect valGradientRect = listLeft.GetRect(12f);
            Widgets.DrawTextureFitted(
                valGradientRect,
                SettingsHelper.GenerateValueGradient((int)vROffsetLeft.width - 12, 12),
                1.0f);
            #endregion
            
            listLeft.End();
            Widgets.EndScrollView();
        }
    }
}