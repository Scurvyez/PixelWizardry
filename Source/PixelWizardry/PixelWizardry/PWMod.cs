using UnityEngine;
using Verse;
using HarmonyLib;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime;

namespace PixelWizardry
{
    public class PWMod : Mod
    {
        public static PWMod mod;
        PWModSettings settings;

        public PWMod(ModContentPack content) : base(content)
        {
            mod = this;
            settings = GetSettings<PWModSettings>();

            var harmony = new Harmony("com.pixelwizardry");

            harmony.Patch(original: AccessTools.PropertyGetter(typeof(ShaderTypeDef), nameof(ShaderTypeDef.Shader)),
                prefix: new HarmonyMethod(typeof(PWMod),
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
                    Log.Message($"[<color=#4494E3FF>Pixel Wizardry</color>] <color=#e36c45FF>Failed to load Shader from path <text>\"{__instance.shaderPath}\"</text></color>");
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
                //Log.Message("[<color=#4494E3FF>Pixel Wizardry</color>] Bundle Path: " + bundlePath);

                AssetBundle bundle = AssetBundle.LoadFromFile(bundlePath);

                if (bundle == null)
                {
                    Log.Message("[<color=#4494E3FF>Pixel Wizardry</color>] <color=#e36c45FF>Failed to load bundle at path:</color> " + bundlePath);
                }

                foreach (var allAssetName in bundle.GetAllAssetNames())
                {
                    //Log.Message($"[<color=#4494E3FF>Pixel Wizardry</color>] - [{allAssetName}]");
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

            // GENERAL SETTINGS
            list.Label("<color=white>General</color>");
            list.Gap(3.00f);

            int decimalPlaces = 2;

            list.Label(label: "PW_IntensityFactor".Translate((10f * settings._IntensityFactor).ToString($"F{decimalPlaces}")), tooltip: "PW_IntensityFactorDesc".Translate());
            settings._IntensityFactor = list.Slider(10f * settings._IntensityFactor, 0f, 10f) / 10f;

            list.End();
        }

        public override string SettingsCategory()
        {
            return "PW_ModName".Translate();
        }
    }

    public class PWModSettings : ModSettings
    {
        private static PWModSettings _instance;

        public float _IntensityFactor = 1.0f;

        public PWModSettings()
        {
            _instance = this;
        }

        public static float IntensityFactor
        {
            get
            {
                return _instance._IntensityFactor;
            }
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref _IntensityFactor, "_IntensityFactor", 1.0f);
        }
    }
}
