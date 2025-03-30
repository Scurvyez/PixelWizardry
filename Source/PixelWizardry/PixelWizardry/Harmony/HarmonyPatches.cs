using HarmonyLib;
using UnityEngine;
using Verse;

namespace PixelWizardry
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            Harmony harmony = new (id: "rimworld.scurvyez.pixelwizardry");

            harmony.Patch(original: AccessTools.Method(typeof(Current), "Notify_LoadedSceneChanged"),
                postfix: new HarmonyMethod(typeof(HarmonyPatches), nameof(Current_Notify_LoadedSceneChanged_Postfix)));
        }
        
        public static void Current_Notify_LoadedSceneChanged_Postfix()
        {
            if (!GenScene.InPlayScene) return;
            GameObject cameraObject = Find.Camera.gameObject;
            cameraObject.AddComponent<FullScreen_HSV>();
            cameraObject.AddComponent<FullScreen_CA>();
        }
    }
}