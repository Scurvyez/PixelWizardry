using RimWorld;
using Verse;
using HarmonyLib;

namespace PixelWizardry
{
    [HarmonyPatch(typeof(PlaySettings), "DoPlaySettingsGlobalControls")]
    public class PlaySettingsDoPlaySettingsGlobalControls_Postfix
    {
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
                row.ToggleableIcon(ref Protanopia, TexButtons.BlackAndWhiteMode, "Protanopia", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Protanomaly, TexButtons.BlackAndWhiteMode, "Protanomaly", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Deuteranopia, TexButtons.BlackAndWhiteMode, "Deuteranopia", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Deuteranomaly, TexButtons.BlackAndWhiteMode, "Deuteranomaly", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Tritanopia, TexButtons.BlackAndWhiteMode, "Tritanopia", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Tritanomaly, TexButtons.BlackAndWhiteMode, "Tritanomaly", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Achromatopsia, TexButtons.BlackAndWhiteMode, "Achromatopsia", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Achromatomaly, TexButtons.BlackAndWhiteMode, "Achromatomaly", SoundDefOf.Mouseover_ButtonToggle);
            }
        }

        public static void ExposeData()
        {
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
