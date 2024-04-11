using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class FullScreenEffects : MonoBehaviour
    {
        public Material cBMMat;
        public Material hsvMat;
        public Material sPEMat;

        public static FullScreenEffects instance;

        public void Start()
        {
            instance = this;
            cBMMat = new Material(PWContentDatabase.ScreenColorBlindness);
            hsvMat = new Material(PWContentDatabase.ScreenHSV);
            sPEMat = new Material (PWContentDatabase.ScreenPositionEffects);
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
            else if (PWModSettings.EnableScreenPositionEffects)
            {
                Graphics.Blit(source, destination, sPEMat);
            }
            else 
            {
                Graphics.Blit(source, destination);
            }
        }
    }
}
