using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class MapComp_UpdateColorBlindnessShader : MapComponent
    {
        FullScreenEffects fullScreenEffects = FullScreenEffects.instance;

        private Pawn trackedPawn;
        private Vector3 trackedPosition;

        public MapComp_UpdateColorBlindnessShader(Map map) : base(map) { }

        public override void FinalizeInit()
        {
            base.FinalizeInit();
            trackedPawn = map.mapPawns.AllPawnsSpawned.RandomElement();
        }

        public override void MapComponentTick()
        {
            base.MapComponentTick();

            if (PWModSettings.EnableColorBlindModes)
            {
                if (PWModSettings.ProtanopiaMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.cBMMat, ColorBlindnessUtility.ColorBlindMode.Protanopia);
                }
                else if (PWModSettings.ProtanomalyMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.cBMMat, ColorBlindnessUtility.ColorBlindMode.Protanomaly);
                }
                else if (PWModSettings.DeuteranopiaMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.cBMMat, ColorBlindnessUtility.ColorBlindMode.Deuteranopia);
                }
                else if (PWModSettings.DeuteranomalyMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.cBMMat, ColorBlindnessUtility.ColorBlindMode.Deuteranomaly);
                }
                else if (PWModSettings.TritanopiaMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.cBMMat, ColorBlindnessUtility.ColorBlindMode.Tritanopia);
                }
                else if (PWModSettings.TritanomalyMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.cBMMat, ColorBlindnessUtility.ColorBlindMode.Tritanomaly);
                }
                else if (PWModSettings.AchromatopsiaMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.cBMMat, ColorBlindnessUtility.ColorBlindMode.Achromatopsia);
                }
                else if (PWModSettings.AchromatomalyMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.cBMMat, ColorBlindnessUtility.ColorBlindMode.Achromatomaly);
                }
                else
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.cBMMat, ColorBlindnessUtility.ColorBlindMode.Normal);
                }
            }

            if (PWModSettings.EnableHSVAdjustment)
            {
                fullScreenEffects.hsvMat.SetFloat("_H", PWModSettings.HAmount);
                fullScreenEffects.hsvMat.SetFloat("_S", PWModSettings.SAmount);
                fullScreenEffects.hsvMat.SetFloat("_V", PWModSettings.VAmount);
            }

            if (PWModSettings.EnableScreenPositionEffects)
            {
                Log.Message($"Tracked Pawn is {trackedPawn}");
                trackedPosition = trackedPawn.DrawPos;
                //fullScreenEffects.sPEMat.SetTexture("_SecondaryTex", TexButtons._SecondaryTex);
                fullScreenEffects.sPEMat.SetVector("_TrackedPosition", trackedPosition);
            }
        }
    }
}
