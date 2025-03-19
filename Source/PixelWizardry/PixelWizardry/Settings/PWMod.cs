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
        private static Color CategoryTextColor => PWLog.MessageMsgCol;
        
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
                PWLog.Error($"Failed to load Shader from path <text>\"{__instance.shaderPath}\"</text>");
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
                    PWLog.Error("Failed to load bundle at path: " + bundlePath);
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
            
            listLeft.Label("HSV Settings".Colorize(CategoryTextColor));
            listLeft.Gap(3.0f);
            
            int decimalPlaces = 0;
            int sliderMinInt = 0;
            int sliderMaxInt = 200; // this is 2 * 10^decimalPlaces
            int normFactor = 2; // normalization factor
            float sliderMultiplier = Mathf.Pow(10f, normFactor);
            
            listLeft.CheckboxLabeled("PW_EnableHSVAdjustment".Translate(), 
                ref _settings._EnableHSVAdjustment, 
                "PW_EnableHSVAdjustmentDesc".Translate());
            
            listLeft.Label(label: "PW_HAmount".Translate((_settings._HAmount * sliderMultiplier)
                    .ToString($"F{decimalPlaces}")), 
                tooltip: "PW_HAmountDesc".Translate());
            
            int hAmountInt = Mathf.RoundToInt(_settings._HAmount * sliderMultiplier);
            hAmountInt = Mathf.RoundToInt(listLeft.Slider(hAmountInt, sliderMinInt, sliderMaxInt));
            _settings._HAmount = hAmountInt / (sliderMaxInt / 2f); // normalize to [0.0, 2.0]
            
            listLeft.Label(label: "PW_SAmount".Translate((_settings._SAmount * sliderMultiplier)
                .ToString($"F{decimalPlaces}")), 
                tooltip: "PW_SAmountDesc".Translate());
            
            int sAmountInt = Mathf.RoundToInt(_settings._SAmount * sliderMultiplier);
            sAmountInt = Mathf.RoundToInt(listLeft.Slider(sAmountInt, sliderMinInt, sliderMaxInt));
            _settings._SAmount = sAmountInt / (sliderMaxInt / 2f);
            
            listLeft.Label(label: "PW_VAmount".Translate((_settings._VAmount * sliderMultiplier)
                .ToString($"F{decimalPlaces}")), 
                tooltip: "PW_VAmountDesc".Translate());
            
            int vAmountInt = Mathf.RoundToInt(_settings._VAmount * sliderMultiplier);
            vAmountInt = Mathf.RoundToInt(listLeft.Slider(vAmountInt, sliderMinInt, sliderMaxInt));
            _settings._VAmount = vAmountInt / (sliderMaxInt / 2f);
            
            listLeft.End();
            Widgets.EndScrollView();
        }
        
        public override string SettingsCategory()
        {
            return "PW_ModName".Translate();
        }
    }
}