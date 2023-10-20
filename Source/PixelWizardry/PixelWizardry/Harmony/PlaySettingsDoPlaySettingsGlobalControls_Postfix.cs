using RimWorld;
using Verse;
using HarmonyLib;
using UnityEngine;
using System;

namespace PixelWizardry
{
    [HarmonyPatch(typeof(PlaySettings), "DoPlaySettingsGlobalControls")]
    public class PlaySettingsDoPlaySettingsGlobalControls_Postfix
    {
        public static bool isBlackAndWhiteMode = false;
        public static bool isSepiaMode = false;
        public static bool isSuperSaturatedMode = false;
        public static bool isCyberpunkMode = false;
        public static bool isRedMode = false;
        public static bool isGreenMode = false;
        public static bool isBlueMode = false;

        [HarmonyPostfix]
        public static void Postfix(WidgetRow row, bool worldView)
        {
            if (!worldView)
            {
                row.ToggleableIcon(ref isBlackAndWhiteMode, TexButtons.BlackAndWhiteMode, "Apply a black and white filter to everything.", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref isSepiaMode, TexButtons.SepiaMode, "Apply a sepia filter to everything.", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref isSuperSaturatedMode, TexButtons.SuperSaturatedMode, "Make everything more vibrant, or darker if already set to B&W.", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref isCyberpunkMode, TexButtons.CyberpunkMode, "Even more vibrant, or darker if already set to B&W!", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref isRedMode, TexButtons.RedMode, "More red.", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref isGreenMode, TexButtons.GreenMode, "More green.", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref isBlueMode, TexButtons.BlueMode, "More blue", SoundDefOf.Mouseover_ButtonToggle);
            }
        }

        public static void ExposeData()
        {
            Scribe_Values.Look(ref isBlackAndWhiteMode, "isBlackAndWhiteMode", defaultValue: false);
            Scribe_Values.Look(ref isSepiaMode, "isSepiaMode", defaultValue: false);
            Scribe_Values.Look(ref isSuperSaturatedMode, "isSuperSaturatedMode", defaultValue: false);
            Scribe_Values.Look(ref isCyberpunkMode, "isCyberpunkMode", defaultValue: false);
            Scribe_Values.Look(ref isRedMode, "isRedMode", defaultValue: false);
            Scribe_Values.Look(ref isGreenMode, "isGreenMode", defaultValue: false);
            Scribe_Values.Look(ref isBlueMode, "isBlueMode", defaultValue: false);
        }
    }
}
