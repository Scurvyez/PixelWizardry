using HarmonyLib;
using Verse;

namespace PixelWizardry
{
    [StaticConstructorOnStartup]
    public static class PixelWizardryMain
    {
        static PixelWizardryMain()
        {
            Log.Message("[<color=#4494E3FF>Pixel Wizardry</color>] 03/15/2024 " + "<color=#ff8c66>[1.5 Update | Older versions will no longer be maintained.]</color>");

            var harmony = new Harmony("com.pixelwizardry");
            harmony.PatchAll();
        }
    }
}
