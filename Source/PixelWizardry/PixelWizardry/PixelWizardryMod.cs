using UnityEngine;
using Verse;
using HarmonyLib;
using System.Runtime.InteropServices;
using System.IO;

namespace PixelWizardry
{
    public class PixelWizardryMod : Mod
    {
        public static PixelWizardryMod mod;
        PWModSettings settings;

        public PixelWizardryMod(ModContentPack content) : base(content)
        {
            mod = this;
            settings = GetSettings<PWModSettings>();

            var harmony = new Harmony("com.pixelwizardry");

            harmony.Patch(original: AccessTools.PropertyGetter(typeof(ShaderTypeDef), nameof(ShaderTypeDef.Shader)),
                prefix: new HarmonyMethod(typeof(PixelWizardryMod),
                nameof(ShaderFromAssetBundle)));

            harmony.PatchAll();
        }

        public static void ShaderFromAssetBundle(ShaderTypeDef __instance, ref Shader ___shaderInt)
        {
            if (__instance is PWShaderTypeDef)
            {
                ___shaderInt = PWContentDatabase.PWBundle.LoadAsset<Shader>(__instance.shaderPath);
                if (___shaderInt is null)
                {
                    PWLog.Error($"Failed to load Shader from path <text>\"{__instance.shaderPath}\"</text>");
                }
            }
        }

        public AssetBundle MainBundle
        {
            get
            {
                string text = "";
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    text = "StandaloneOSX";
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    text = "StandaloneWindows64";
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    text = "StandaloneLinux64";
                }
                string bundlePath = Path.Combine(base.Content.RootDir, "Materials\\Bundles\\" + text + "\\pixelwizardrybundle");
                //PWLog.Message("Bundle Path: " + bundlePath);

                AssetBundle bundle = AssetBundle.LoadFromFile(bundlePath);

                if (bundle == null)
                {
                    PWLog.Error("Failed to load bundle at path: " + bundlePath);
                }

                foreach (var allAssetName in bundle.GetAllAssetNames())
                {
                    //PWLog.Message($"[{allAssetName}]");
                }

                return bundle;
            }
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);

            Listing_Standard list = new Listing_Standard();
            Rect viewRect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height);
            list.Begin(viewRect);

            // Color Blindness Settings
            list.Label("<color=white>Color Blindness Settings</color>");
            list.Gap(3.0f);

            list.CheckboxLabeled("PW_EnableColorBlindMode".Translate(), ref settings._EnableColorBlindModes, "PW_EnableColorBlindModeDesc".Translate());

            DrawSettingWithTexture(list, "PW_SettingProtanopia".Translate(), ref settings._ProtanopiaMode, TexButtons.ProtanopiaMode);
            DrawSettingWithTexture(list, "PW_SettingProtanomaly".Translate(), ref settings._ProtanomalyMode, TexButtons.ProtanomalyMode);
            DrawSettingWithTexture(list, "PW_SettingDeuteranopia".Translate(), ref settings._DeuteranopiaMode, TexButtons.DeuteranopiaMode);
            DrawSettingWithTexture(list, "PW_SettingDeuteranomaly".Translate(), ref settings._DeuteranomalyMode, TexButtons.DeuteranomalyMode);
            DrawSettingWithTexture(list, "PW_SettingTritanopia".Translate(), ref settings._TritanopiaMode, TexButtons.TritanopiaMode);
            DrawSettingWithTexture(list, "PW_SettingTritanomaly".Translate(), ref settings._TritanomalyMode, TexButtons.TritanomalyMode);
            DrawSettingWithTexture(list, "PW_SettingAchromatopsia".Translate(), ref settings._AchromatopsiaMode, TexButtons.AchromatopsiaMode);
            DrawSettingWithTexture(list, "PW_SettingAchromatomaly".Translate(), ref settings._AchromatomalyMode, TexButtons.AchromatomalyMode);

            list.Gap(15.0f);

            // HSV Settings
            list.Label("HSV Settings");
            list.Gap(3.0f);

            int decimalPlaces = 0;
            int sliderMinInt = 0;
            int sliderMaxInt = 200; // this is 2 * 10^decimalPlaces
            int normFactor = 2; // normalization factor
            float sliderMultiplier = Mathf.Pow(10f, normFactor);

            list.CheckboxLabeled("PW_EnableHSVAdjustment".Translate(), ref settings._EnableHSVAdjustment, "PW_EnableHSVAdjustmentDesc".Translate());

            list.Label(label: "PW_HAmount".Translate((settings._HAmount * sliderMultiplier).ToString($"F{decimalPlaces}")), tooltip: "PW_HAmountDesc".Translate());
            int hAmountInt = Mathf.RoundToInt(settings._HAmount * sliderMultiplier);
            hAmountInt = Mathf.RoundToInt(list.Slider(hAmountInt, sliderMinInt, sliderMaxInt));
            settings._HAmount = hAmountInt / (sliderMaxInt / 2f); // normalize to [0.0, 2.0]

            list.Label(label: "PW_SAmount".Translate((settings._SAmount * sliderMultiplier).ToString($"F{decimalPlaces}")), tooltip: "PW_SAmountDesc".Translate());
            int sAmountInt = Mathf.RoundToInt(settings._SAmount * sliderMultiplier);
            sAmountInt = Mathf.RoundToInt(list.Slider(sAmountInt, sliderMinInt, sliderMaxInt));
            settings._SAmount = sAmountInt / (sliderMaxInt / 2f);

            list.Label(label: "PW_VAmount".Translate((settings._VAmount * sliderMultiplier).ToString($"F{decimalPlaces}")), tooltip: "PW_VAmountDesc".Translate());
            int vAmountInt = Mathf.RoundToInt(settings._VAmount * sliderMultiplier);
            vAmountInt = Mathf.RoundToInt(list.Slider(vAmountInt, sliderMinInt, sliderMaxInt));
            settings._VAmount = vAmountInt / (sliderMaxInt / 2f);

            list.Gap(15.0f);

            // Screen Position Effects Settings
            list.Label("Screen Position Effects Settings");
            list.Gap(3.0f);

            list.CheckboxLabeled("PW_EnableScreenPositionEffects".Translate(), ref settings._EnableScreenPositionEffects, "PW_EnableScreenPositionEffectsDesc".Translate());

            list.End();
        }

        private static void DrawSettingWithTexture(Listing_Standard list, string label, ref bool value, Texture2D texture)
        {
            Rect rect = list.GetRect(24f);
            Widgets.Label(rect.LeftPartPixels(30f), new GUIContent(texture)); // draw our texture
            Widgets.CheckboxLabeled(rect.RightPartPixels(rect.width - 30f), label, ref value); // draw our checkbox with label
        }

        public override string SettingsCategory()
        {
            return "PW_ModName".Translate();
        }
    }

    public class PWModSettings : ModSettings
    {
        private static PWModSettings _instance;

        public bool _EnableColorBlindModes = false;
        public bool _ProtanopiaMode = false;
        public bool _ProtanomalyMode = false;
        public bool _DeuteranopiaMode = false;
        public bool _DeuteranomalyMode = false;
        public bool _TritanopiaMode = false;
        public bool _TritanomalyMode = false;
        public bool _AchromatopsiaMode = false;
        public bool _AchromatomalyMode = false;

        public bool _EnableHSVAdjustment = false;
        public float _HAmount = 1f;
        public float _SAmount = 1f;
        public float _VAmount = 1f;

        public bool _EnableScreenPositionEffects = false;
        
        public PWModSettings()
        {
            _instance = this;
        }

        public static bool EnableColorBlindModes
        {
            get
            {
                return _instance._EnableColorBlindModes;
            }
        }

        public static bool ProtanopiaMode
        {
            get
            {
                return _instance._ProtanopiaMode;
            }
        }

        public static bool ProtanomalyMode
        {
            get
            {
                return _instance._ProtanomalyMode;
            }
        }

        public static bool DeuteranopiaMode
        {
            get
            {
                return _instance._DeuteranopiaMode;
            }
        }

        public static bool DeuteranomalyMode
        {
            get
            {
                return _instance._DeuteranomalyMode;
            }
        }

        public static bool TritanopiaMode
        {
            get
            {
                return _instance._TritanopiaMode;
            }
        }

        public static bool TritanomalyMode
        {
            get
            {
                return _instance._TritanomalyMode;
            }
        }

        public static bool AchromatopsiaMode
        {
            get
            {
                return _instance._AchromatopsiaMode;
            }
        }

        public static bool AchromatomalyMode
        {
            get
            {
                return _instance._AchromatomalyMode;
            }
        }

        public static bool EnableHSVAdjustment
        {
            get
            {
                return _instance._EnableHSVAdjustment;
            }
        }

        public static float HAmount
        {
            get
            {
                return _instance._HAmount;
            }
        }

        public static float SAmount
        {
            get
            {
                return _instance._SAmount;
            }
        }

        public static float VAmount
        {
            get
            {
                return _instance._VAmount;
            }
        }

        public static bool EnableScreenPositionEffects
        {
            get
            {
                return _instance._EnableScreenPositionEffects;
            }
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref _EnableColorBlindModes, "_EnableColorBlindModes", false);

            Scribe_Values.Look(ref _ProtanopiaMode, "_ProtanopiaMode", false);
            Scribe_Values.Look(ref _ProtanomalyMode, "_ProtanomalyMode", false);
            Scribe_Values.Look(ref _DeuteranopiaMode, "_DeuteranopiaMode", false);
            Scribe_Values.Look(ref _DeuteranomalyMode, "_DeuteranomalyMode", false);
            Scribe_Values.Look(ref _TritanopiaMode, "_TritanopiaMode", false);
            Scribe_Values.Look(ref _TritanomalyMode, "_TritanomalyMode", false);
            Scribe_Values.Look(ref _AchromatopsiaMode, "_AchromatopsiaMode", false);
            Scribe_Values.Look(ref _AchromatomalyMode, "_AchromatomalyMode", false);

            Scribe_Values.Look(ref _EnableHSVAdjustment, "_EnableHSVAdjustment", false);
            Scribe_Values.Look(ref _HAmount, "_HAmount", 1f);
            Scribe_Values.Look(ref _SAmount, "_SAmount", 1f);
            Scribe_Values.Look(ref _VAmount, "_VAmount", 1f);

            Scribe_Values.Look(ref _EnableScreenPositionEffects, "_EnableScreenPositionEffects", false);
        }
    }
}
