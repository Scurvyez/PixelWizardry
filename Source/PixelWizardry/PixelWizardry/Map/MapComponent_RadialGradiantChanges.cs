using UnityEngine;
using Verse;
using System.Collections.Generic;

namespace PixelWizardry
{
    /*
    [StaticConstructorOnStartup]
    public class MapComponent_RadialGradiantChanges : MapComponent
    {
        private static readonly Texture2D RadialGradientChange = ContentFinder<Texture2D>.Get("Map/Effects/RadialGradientChangeBlue");
        private ColorBlindMode currentColorBlindMode = ColorBlindMode.Protanomaly;  // Default to normal vision
        private Color redAdjustment;
        private Color greenAdjustment;
        private Color blueAdjustment;

        private List<Pawn> pawns;

        private Material mapReactiveMat;
        private MaterialPropertyBlock propertyBlock;
        private float drawSizeFactor = 15.75f;
        private bool shouldFade = true;

        public MapComponent_RadialGradiantChanges(Map map) : base(map)
        {
            
        }

        public override void FinalizeInit()
        {
            pawns = map.mapPawns.AllPawnsSpawned;

            mapReactiveMat = new Material(PWContentDatabase.ColorBlindness);
            propertyBlock = new MaterialPropertyBlock();

            ApplyColorBlindMode(currentColorBlindMode);

            // Set the adjustments in the material
            //mapReactiveMat.SetColor("_R", Color.red);
            //mapReactiveMat.SetColor("_G", Color.green);
            //mapReactiveMat.SetColor("_B", Color.blue);

            mapReactiveMat.SetTexture("_MainTex", RadialGradientChange);
        }

        public override void MapComponentTick()
        {
            base.MapComponentTick();

            //ApplyColorBlindMode(currentColorBlindMode);
        }

        public override void MapComponentUpdate()
        {
            // apply the effect at the position of each pawn
            foreach (Pawn pawn in pawns)
            {
                Vector3 drawPosition = pawn.DrawPos;
                DrawMapEffect(shouldFade, 1.0f, mapReactiveMat, drawSizeFactor, drawPosition);
            }
        }

        public void DrawMapEffect(bool shouldFade, float opacity, Material mat, float drawSizeFactor, Vector3 drawPos)
        {
            Matrix4x4 matrix = Matrix4x4.TRS(drawPos + new Vector3(0f, AltitudeLayer.VisEffects.AltitudeFor(), 0f), Quaternion.identity, new Vector3(drawSizeFactor, 1f, drawSizeFactor));
            Material finalMat = shouldFade ? FadedMaterialPool.FadedVersionOf(mat, opacity) : mat;
            Graphics.DrawMesh(MeshPool.plane10, matrix, finalMat, 0);
        }

        // Method to apply color blindness mode
        public void ApplyColorBlindMode(ColorBlindMode mode)
        {
            currentColorBlindMode = mode;

            // Determine color adjustments based on the selected mode
            // Adjust these colors based on your mapping for each mode
            redAdjustment = GetRedAdjustmentForMode(mode);
            greenAdjustment = GetGreenAdjustmentForMode(mode);
            blueAdjustment = GetBlueAdjustmentForMode(mode);

            // Set the adjustments in the material
            mapReactiveMat.SetColor("_R", redAdjustment);
            mapReactiveMat.SetColor("_G", greenAdjustment);
            mapReactiveMat.SetColor("_B", blueAdjustment);
        }

        private Color GetRedAdjustmentForMode(ColorBlindMode mode)
        {
            switch (mode)
            {
                case ColorBlindMode.Protanopia:
                    return new Color(0.567f, 0.433f, 0.0f);
                case ColorBlindMode.Protanomaly:
                    return new Color(0.817f, 0.183f, 0.0f);
                default:
                    return Color.red;
            }
        }

        private Color GetGreenAdjustmentForMode(ColorBlindMode mode)
        {
            switch (mode)
            {
                case ColorBlindMode.Protanopia:
                    return new Color(0.558f, 0.442f, 0.0f);
                case ColorBlindMode.Protanomaly:
                    return new Color(0.333f, 0.667f, 0.0f);
                case ColorBlindMode.Deuteranopia:
                    return new Color(0.625f, 0.375f, 0.0f);
                case ColorBlindMode.Deuteranomaly:
                    return new Color(0.8f, 0.2f, 0.0f);
                default:
                    return Color.green;
            }
        }

        private Color GetBlueAdjustmentForMode(ColorBlindMode mode)
        {
            switch (mode)
            {
                case ColorBlindMode.Protanopia:
                    return new Color(0.0f, 0.241f, 0.758f);
                case ColorBlindMode.Protanomaly:
                    return new Color(0.0f, 0.125f, 0.875f);
                case ColorBlindMode.Tritanopia:
                    return new Color(0.95f, 0.05f, 0.0f);
                case ColorBlindMode.Tritanomaly:
                    return new Color(0.967f, 0.033f, 0.0f);
                default:
                    return Color.blue;
            }
        }

        public enum ColorBlindMode
        {
            Normal = 0,
            Protanopia = 1,
            Protanomaly = 2,
            Deuteranopia = 3,
            Deuteranomaly = 4,
            Tritanopia = 5,
            Tritanomaly = 6,
            Achromatopsia = 7,
            Achromatomaly = 8,
        }
    }
    */
}
