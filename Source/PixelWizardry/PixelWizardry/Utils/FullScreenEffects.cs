using UnityEngine;

namespace PixelWizardry
{
    public class FullScreenEffects : MonoBehaviour
    {
        public Material material;

        public void Start()
        {
            material = new Material(PWContentDatabase.ScreenChangeColors);
        }

        public void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            Graphics.Blit(source, destination, material);
        }
    }
}
