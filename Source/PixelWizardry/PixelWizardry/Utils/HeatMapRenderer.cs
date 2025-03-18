using UnityEngine;

namespace PixelWizardry
{
    public class HeatMapRenderer : MonoBehaviour
    {
        public Material heatmapMaterial;
        public static HeatMapRenderer instance;
        
        public void Start()
        {
            instance = this;
            heatmapMaterial = new Material(PWContentDatabase.HeatmapEffect);
        }
        
        public void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            Graphics.Blit(source, destination, heatmapMaterial);
        }
    }
}