using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class MapComp_UpdateColorBlindnessShader : MapComponent
    {
        FullScreenEffects fullScreenEffects = FullScreenEffects.instance;

        //private Pawn trackedPawn;
        private Vector3 trackedPosition;

        public MapComp_UpdateColorBlindnessShader(Map map) : base(map) { }

        public override void FinalizeInit()
        {
            base.FinalizeInit();
            //trackedPawn = map.mapPawns.AllPawnsSpawned.RandomElement();
        }

        public override void MapComponentTick()
        {
            base.MapComponentTick();

            if (PWModSettings.EnableColorBlindModes)
            {
                if (PWModSettings.ProtanopiaMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.colorBlindModeMat, ColorBlindnessUtility.ColorBlindMode.Protanopia);
                }
                else if (PWModSettings.ProtanomalyMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.colorBlindModeMat, ColorBlindnessUtility.ColorBlindMode.Protanomaly);
                }
                else if (PWModSettings.DeuteranopiaMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.colorBlindModeMat, ColorBlindnessUtility.ColorBlindMode.Deuteranopia);
                }
                else if (PWModSettings.DeuteranomalyMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.colorBlindModeMat, ColorBlindnessUtility.ColorBlindMode.Deuteranomaly);
                }
                else if (PWModSettings.TritanopiaMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.colorBlindModeMat, ColorBlindnessUtility.ColorBlindMode.Tritanopia);
                }
                else if (PWModSettings.TritanomalyMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.colorBlindModeMat, ColorBlindnessUtility.ColorBlindMode.Tritanomaly);
                }
                else if (PWModSettings.AchromatopsiaMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.colorBlindModeMat, ColorBlindnessUtility.ColorBlindMode.Achromatopsia);
                }
                else if (PWModSettings.AchromatomalyMode)
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.colorBlindModeMat, ColorBlindnessUtility.ColorBlindMode.Achromatomaly);
                }
                else
                {
                    ColorBlindnessUtility.SetColorBlindnessProperties(fullScreenEffects.colorBlindModeMat, ColorBlindnessUtility.ColorBlindMode.Normal);
                }
            }

            if (PWModSettings.EnableHSVAdjustment)
            {
                fullScreenEffects.hsvMat.SetFloat("_H", PWModSettings.HAmount);
                fullScreenEffects.hsvMat.SetFloat("_S", PWModSettings.SAmount);
                fullScreenEffects.hsvMat.SetFloat("_V", PWModSettings.VAmount);
            }

            /*
            if (PWModSettings.EnableScreenPositionEffects)
            {
                trackedPosition = trackedPawn.DrawPos;
                fullScreenEffects.screenPositionEffectsMat.SetVector("_TrackedPosition", trackedPosition);
            }
            */
        }
    }
}
