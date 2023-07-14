using System;
using HarmonyLib;
using Verse;
using UnityEngine;

namespace PixelWizardry
{
    [HarmonyPatch(typeof(MaterialPool), "MatFrom", new Type[] { typeof(MaterialRequest) })]
    public static class MatFrom_Patch
    {
        [HarmonyPostfix]
        public static void MatFromPostFix(MaterialRequest req, ref Material __result)
        {
            if (__result != null
                && (__result.shader == PWContentDatabase.LinearDodge
                || __result.shader == PWContentDatabase.Subtract
                || __result.shader == PWContentDatabase.LinearBurn
                || __result.shader == PWContentDatabase.Screen
                || __result.shader == PWContentDatabase.Multiply
                || __result.shader == PWContentDatabase.LinearDodgePulse
                || __result.shader == PWContentDatabase.SubtractPulse
                || __result.shader == PWContentDatabase.TransparentRGBToBlack
                || __result.shader == PWContentDatabase.TransparentRGBToBlackPulse
                || __result.shader == PWContentDatabase.ScreenPulse
                || __result.shader == PWContentDatabase.TransparentPulse))
            {
                //Log.Message("[<color=#4494E3FF>Pixel Wizardry</color>] MatFrom_Patch: Material shader = " + __result.shader.name);
                WindManager.Notify_PlantMaterialCreated(__result);
            }
        }
    }
}
