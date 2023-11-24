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
                row.ToggleableIcon(ref Protanopia, TexButtons.ProtanopiaMode, "Protanopia mode", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Protanomaly, TexButtons.ProtanomalyMode, "Protanomaly mode", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Deuteranopia, TexButtons.DeuteranopiaMode, "Deuteranopia mode", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Deuteranomaly, TexButtons.DeuteranomalyMode, "Deuteranomaly mode", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Tritanopia, TexButtons.TritanopiaMode, "Tritanopia mode", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Tritanomaly, TexButtons.TritanomalyMode, "Tritanomaly mode", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Achromatopsia, TexButtons.AchromatopsiaMode, "Achromatopsia mode", SoundDefOf.Mouseover_ButtonToggle);
                row.ToggleableIcon(ref Achromatomaly, TexButtons.AchromatomalyMode, "Achromatomaly mode", SoundDefOf.Mouseover_ButtonToggle);
            }
        }

        public static void ExposeData()
        {
            Scribe_Values.Look(ref Protanopia, "Protanopia", defaultValue: false);
            Scribe_Values.Look(ref Protanomaly, "Protanomaly", defaultValue: false);
            Scribe_Values.Look(ref Deuteranopia, "Deuteranopia", defaultValue: false);
            Scribe_Values.Look(ref Deuteranomaly, "Deuteranomaly", defaultValue: false);
            Scribe_Values.Look(ref Tritanopia, "Tritanopia", defaultValue: false);
            Scribe_Values.Look(ref Tritanomaly, "Tritanomaly", defaultValue: false);
            Scribe_Values.Look(ref Achromatopsia, "Achromatopsia", defaultValue: false);
            Scribe_Values.Look(ref Achromatomaly, "Achromatomaly", defaultValue: false);
        }
    }
}
