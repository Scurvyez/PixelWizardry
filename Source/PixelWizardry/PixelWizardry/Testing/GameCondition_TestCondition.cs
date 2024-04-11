using RimWorld;
using UnityEngine;
using Verse;

namespace PixelWizardry
{
    /// <summary>
    /// This is a bare minimum GameCondition worker class for changing the final color of the sky.
    /// </summary>
    public class GameCondition_TestCondition : GameCondition
    {
        private static Color skyColor = new Color(0.9f, 0.1f, 0.1f); // color of the sky
        private static Color shadowColor = Color.white;              // color of any shadows
        private static Color overlayColor = new Color(1f, 1f, 1f);   // stength (opacity) of the sky color
        private static float saturation = 0.75f;                     // saturation of the sky color (0 = grayscale)
        private static float glow = 0.25f;                           // strength of any actual light in each cell on the map

        public override int TransitionTicks => 120;                  // how quickly the sky changes color

        public override float SkyTargetLerpFactor(Map map)
        {
            return GameConditionUtility.LerpInOutValue(this, TransitionTicks);
        }

        public static readonly SkyColorSet TestSkyColors = new SkyColorSet(skyColor, shadowColor, overlayColor, saturation);

        public override SkyTarget? SkyTarget(Map map)
        {
            return new SkyTarget(glow, TestSkyColors, 1f, 1f);
        }
    }
}
