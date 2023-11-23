using UnityEngine;

namespace PixelWizardry
{
    public class ColorBlindnessUtility
    {
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

        public static void SetColorBlindnessProperties(Material material, ColorBlindMode mode)
        {
            switch (mode)
            {
                case ColorBlindMode.Protanopia:
                    material.SetColor("_R", new Color(0.56667f, 0.43333f, 0, 1));
                    material.SetColor("_G", new Color(0.55833f, 0.44167f, 0, 1));
                    material.SetColor("_B", new Color(0, 0.24167f, 0.75833f, 1));
                    break;
                case ColorBlindMode.Protanomaly:
                    material.SetColor("_R", new Color(0.81667f, 0.18333f, 0, 1));
                    material.SetColor("_G", new Color(0.33333f, 0.66667f, 0, 1));
                    material.SetColor("_B", new Color(0, 0.125f, 0.875f, 1));
                    break;
                case ColorBlindMode.Deuteranopia:
                    material.SetColor("_R", new Color(0.625f, 0.375f, 0, 1));
                    material.SetColor("_G", new Color(0.7f, 0.3f, 0, 1));
                    material.SetColor("_B", new Color(0, 0.3f, 0.7f, 1));
                    break;
                case ColorBlindMode.Deuteranomaly:
                    material.SetColor("_R", new Color(0.8f, 0.2f, 0, 1));
                    material.SetColor("_G", new Color(0, 0.25833f, 0.74167f, 1));
                    material.SetColor("_B", new Color(0, 0.14167f, 0.85833f, 1));
                    break;
                case ColorBlindMode.Tritanopia:
                    material.SetColor("_R", new Color(0.95f, 0.05f, 0, 1));
                    material.SetColor("_G", new Color(0, 0.43333f, 0.56667f, 1));
                    material.SetColor("_B", new Color(0, 0.475f, 0.525f, 1));
                    break;
                case ColorBlindMode.Tritanomaly:
                    material.SetColor("_R", new Color(0.96667f, 0.03333f, 0, 1));
                    material.SetColor("_G", new Color(0, 0.73333f, 0.26667f, 1));
                    material.SetColor("_B", new Color(0, 0.18333f, 0.81667f, 1));
                    break;
                case ColorBlindMode.Achromatopsia:
                    material.SetColor("_R", new Color(0.299f, 0.587f, 0.114f, 1));
                    material.SetColor("_G", new Color(0.229f, 0.587f, 0.114f, 1));
                    material.SetColor("_B", new Color(0.299f, 0.587f, 0.114f, 1));
                    break;
                case ColorBlindMode.Achromatomaly:
                    material.SetColor("_R", new Color(0.618f, 0.32f, 0.062f, 1));
                    material.SetColor("_G", new Color(0.163f, 0.775f, 0.062f, 1));
                    material.SetColor("_B", new Color(0.163f, 0.32f, 0.516f, 1));
                    break;
                default:
                    material.SetColor("_R", new Color(1, 0, 0, 1));
                    material.SetColor("_G", new Color(0, 1, 0, 1));
                    material.SetColor("_B", new Color(0, 0, 1, 1));
                    break;
            }
        }
    }
}
