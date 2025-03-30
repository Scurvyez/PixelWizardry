using UnityEngine;

namespace PixelWizardry
{
    public class FullScreen_HSV : MonoBehaviour
    {
        public Material HSVMat;
        public static FullScreen_HSV Instance;
        
        public void Start()
        {
            Instance = this;
            HSVMat = new Material(PWContentDatabase.ScreenHSV);
        }
        
        public void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (PWSettings.EnableHSVAdjustment)
            {
                Graphics.Blit(source, destination, HSVMat);
            }
            else 
            {
                Graphics.Blit(source, destination);
            }
        }
    }
}