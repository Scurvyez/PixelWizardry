using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class FullScreenEffects : MonoBehaviour
    {
        public Material cBMMat;
        public Material hsvMat;

        public static FullScreenEffects instance;

        public void Start()
        {
            instance = this;
            cBMMat = new Material(PWContentDatabase.ScreenColorBlindness);
            hsvMat = new Material(PWContentDatabase.ScreenHSV);
        }

        public void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (PWModSettings.EnableColorBlindModes)
            {
                Graphics.Blit(source, destination, cBMMat);
            }
            else if (PWModSettings.EnableHSVAdjustment)
            {
                Graphics.Blit(source, destination, hsvMat);
            }
            else 
            {
                Graphics.Blit(source, destination);
            }
        }
    }
}
