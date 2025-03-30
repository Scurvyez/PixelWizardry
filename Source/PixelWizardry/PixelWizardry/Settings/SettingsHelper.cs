using UnityEngine;
using Verse;

namespace PixelWizardry
{
    [StaticConstructorOnStartup]
    public static class SettingsHelper
    {
        public static Texture2D GenerateHueGradient(int width, int height)
        {
            Texture2D texture = new(width, height);
            for (int x = 0; x < width; x++)
            {
                Color color = Color.HSVToRGB((float)x / width, 1f, 1f);
                for (int y = 0; y < height; y++)
                {
                    texture.SetPixel(x, y, color);
                }
            }
            texture.Apply();
            return texture;
        }
        
        public static Texture2D GenerateSaturationGradient(int width, int height, float hue)
        {
            Texture2D texture = new(width, height);
            for (int x = 0; x < width; x++)
            {
                Color color = Color.HSVToRGB(hue, (float)x / width, 1f);
                for (int y = 0; y < height; y++)
                {
                    texture.SetPixel(x, y, color);
                }
            }
            texture.Apply();
            return texture;
        }
        
        public static Texture2D GenerateValueGradient(int width, int height)
        {
            Texture2D texture = new(width, height);
            for (int x = 0; x < width; x++)
            {
                Color color = Color.HSVToRGB(0f, 0f, (float)x / width);
                for (int y = 0; y < height; y++)
                {
                    texture.SetPixel(x, y, color);
                }
            }
            texture.Apply();
            return texture;
        }
    }
}