using UnityEngine;
using Verse;
using HarmonyLib;
using System.Runtime.InteropServices;
using System.IO;
using System;

namespace PixelWizardry
{
    public class PWMod : Mod
    {
        public static PWMod mod;
        //private static ColorBlindnessUtility.ColorBlindMode selectedColorBlindMode = ColorBlindnessUtility.ColorBlindMode.Normal;

        public PWMod(ModContentPack content) : base(content)
        {
            mod = this;
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

        /*
        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);

            Listing_Standard list = new Listing_Standard();

            list.Begin(inRect);
            list.Label("Select Color Blindness Mode:");

            // Add options for color blindness modes
            foreach (ColorBlindnessUtility.ColorBlindMode mode in Enum.GetValues(typeof(ColorBlindnessUtility.ColorBlindMode)))
            {
                bool isSelected = selectedColorBlindMode == mode;
                if (list.RadioButton(mode.ToString(), isSelected))
                {
                    selectedColorBlindMode = mode;
                }
            }

            list.End();
        }

        public override string SettingsCategory()
        {
            return "Pixel Wizardry Mod Settings";
        }
        */
    }

    /*
    public class PWModSettings : ModSettings
    {
        public ColorBlindnessUtility.ColorBlindMode SelectedColorBlindMode;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref SelectedColorBlindMode, "SelectedColorBlindMode", ColorBlindnessUtility.ColorBlindMode.Normal);
        }
    }
    */
}
