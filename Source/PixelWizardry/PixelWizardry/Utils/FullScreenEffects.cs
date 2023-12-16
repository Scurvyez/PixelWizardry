using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class FullScreenEffects : MonoBehaviour
    {
        public Material colorBlindModeMat;
        public Material hsvMat;
        public Material screenPositionEffectsMat;

        public static FullScreenEffects instance;

        public void Start()
        {
            instance = this;
            colorBlindModeMat = new Material(PWContentDatabase.ScreenColorBlindness);
            hsvMat = new Material(PWContentDatabase.ScreenHSV);
            screenPositionEffectsMat = new Material (PWContentDatabase.ScreenPositionEffects);
        }

        public void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (PWModSettings.EnableColorBlindModes)
            {
                Graphics.Blit(source, destination, colorBlindModeMat);
            }
            else if (PWModSettings.EnableHSVAdjustment)
            {
                Graphics.Blit(source, destination, hsvMat);
            }
            /*
            else if (PWModSettings.EnableScreenPositionEffects)
            {
                Graphics.Blit(source, destination, screenPositionEffectsMat);
            }
            */
            else 
            {
                Graphics.Blit(source, destination);
            }
        }
    }
}
