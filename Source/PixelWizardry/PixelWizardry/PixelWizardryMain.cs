using HarmonyLib;
using Verse;

namespace PixelWizardry
{
    [StaticConstructorOnStartup]
    public static class PixelWizardryMain
    {
        static PixelWizardryMain()
        {
            PWLog.Message("[1.5 Update | Older versions will no longer be maintained.]");

            Harmony harmony = new ("com.pixelwizardry");
            harmony.PatchAll();
        }
    }
}
