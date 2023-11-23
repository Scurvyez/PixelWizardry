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
        //public static bool isBlackAndWhiteMode = false;
        //public static bool isSepiaMode = false;
        //public static bool isSuperSaturatedMode = false;
        //public static bool isCyberpunkMode = false;
        //public static bool isRedMode = false;
        //public static bool isGreenMode = false;
        //public static bool isBlueMode = false;

        public static bool Normal = false;
        public static bool Protanopia = false;
        public static bool Protanomaly = false;
        public static bool Deuteranopia = false;
        public static bool Deuteranomaly = false;
        public static bool Tritanopia = false;
        public static bool Tritanomaly = false;
        public static bool Achromatopsia = false;
        public static bool Achromatomaly = false;

        [HarmonyPostfix]
        public static void Postfix(WidgetRow row, bool worldView)
        {
            if (!worldView)
            {
                //row.ToggleableIcon(ref isBlackAndWhiteMode, TexButtons.BlackAndWhiteMode, "Apply a black and white filter to everything.", SoundDefOf.Mouseover_ButtonToggle);
                //row.ToggleableIcon(ref isSepiaMode, TexButtons.SepiaMode, "Apply a sepia filter to everything.", SoundDefOf.Mouseover_ButtonToggle);
                //row.ToggleableIcon(ref isSuperSaturatedMode, TexButtons.SuperSaturatedMode, "Make everything more vibrant, or darker if already set to B&W.", SoundDefOf.Mouseover_ButtonToggle);
                //row.ToggleableIcon(ref isCyberpunkMode, TexButtons.CyberpunkMode, "Even more vibrant, or darker if already set to B&W!", SoundDefOf.Mouseover_ButtonToggle);
                //row.ToggleableIcon(ref isRedMode, TexButtons.RedMode, "More red.", SoundDefOf.Mouseover_ButtonToggle);
                //row.ToggleableIcon(ref isGreenMode, TexButtons.GreenMode, "More green.", SoundDefOf.Mouseover_ButtonToggle);
                //row.ToggleableIcon(ref isBlueMode, TexButtons.BlueMode, "More blue", SoundDefOf.Mouseover_ButtonToggle);

                row.ToggleableIcon(ref Normal, TexButtons.BlackAndWhiteMode, "Normal colors", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Protanopia, TexButtons.BlackAndWhiteMode, "Normal colors", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Protanomaly, TexButtons.BlackAndWhiteMode, "Normal colors", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Deuteranopia, TexButtons.BlackAndWhiteMode, "Normal colors", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Deuteranomaly, TexButtons.BlackAndWhiteMode, "Normal colors", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Tritanopia, TexButtons.BlackAndWhiteMode, "Normal colors", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Tritanomaly, TexButtons.BlackAndWhiteMode, "Normal colors", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Achromatopsia, TexButtons.BlackAndWhiteMode, "Normal colors", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Achromatomaly, TexButtons.BlackAndWhiteMode, "Normal colors", SoundDefOf.Mouseover_ButtonToggle);
            }
        }

        public static void ExposeData()
        {
            //Scribe_Values.Look(ref isBlackAndWhiteMode, "isBlackAndWhiteMode", defaultValue: false);
            //Scribe_Values.Look(ref isSepiaMode, "isSepiaMode", defaultValue: false);
            //Scribe_Values.Look(ref isSuperSaturatedMode, "isSuperSaturatedMode", defaultValue: false);
            //Scribe_Values.Look(ref isCyberpunkMode, "isCyberpunkMode", defaultValue: false);
            //Scribe_Values.Look(ref isRedMode, "isRedMode", defaultValue: false);
            //Scribe_Values.Look(ref isGreenMode, "isGreenMode", defaultValue: false);
            //Scribe_Values.Look(ref isBlueMode, "isBlueMode", defaultValue: false);

            Scribe_Values.Look(ref Normal, "Normal", defaultValue: false);
            Scribe_Values.Look(ref Protanopia, "Normal", defaultValue: false);
            Scribe_Values.Look(ref Protanomaly, "Normal", defaultValue: false);
            Scribe_Values.Look(ref Deuteranopia, "Normal", defaultValue: false);
            Scribe_Values.Look(ref Deuteranomaly, "Normal", defaultValue: false);
            Scribe_Values.Look(ref Tritanopia, "Normal", defaultValue: false);
            Scribe_Values.Look(ref Tritanomaly, "Normal", defaultValue: false);
            Scribe_Values.Look(ref Achromatopsia, "Normal", defaultValue: false);
            Scribe_Values.Look(ref Achromatomaly, "Normal", defaultValue: false);
        }
    }
}
