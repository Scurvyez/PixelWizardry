using LudeonTK;
using UnityEngine;

namespace PixelWizardry
{
    public class FullScreen_CA : MonoBehaviour
    {
        public Material CAMat;
        public static FullScreen_CA Instance;
        
        [TweakValue("Pixel Wizardry", 0f, 1f)]
        public static float Active = 0;
        [TweakValue("Pixel Wizardry", 0f, 1f)]
        public static float R_Offset = 0.005f;
        [TweakValue("Pixel Wizardry", 0f, 1f)]
        public static float G_Offset = 0.008f;
        [TweakValue("Pixel Wizardry", 0f, 1f)]
        public static float B_Offset = 0.011f;
        [TweakValue("Pixel Wizardry", -1f, 1f)]
        public static float R_OffsetDir_X = 1f;
        [TweakValue("Pixel Wizardry", -1f, 1f)]
        public static float R_OffsetDir_Y = -1f;
        [TweakValue("Pixel Wizardry", -1f, 1f)]
        public static float G_OffsetDir_X = 1f;
        [TweakValue("Pixel Wizardry", -1f, 1f)]
        public static float G_OffsetDir_Y = -1f;
        [TweakValue("Pixel Wizardry", -1f, 1f)]
        public static float B_OffsetDir_X = 1f;
        [TweakValue("Pixel Wizardry", -1f, 1f)]
        public static float B_OffsetDir_Y = -1f;
        
        public Vector2 R_OffsetDir => new (R_OffsetDir_X, R_OffsetDir_Y);
        public Vector2 G_OffsetDir => new (G_OffsetDir_X, G_OffsetDir_Y);
        public Vector2 B_OffsetDir => new (B_OffsetDir_X, B_OffsetDir_Y);
        public bool IsActive => Active >= 1f;
        
        public void Start()
        {
            Instance = this;
            CAMat = new Material(PWContentDatabase.ScreenChromaticAberration);
        }
        
        public void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (IsActive)
            {
                UpdateShaderParams();
                Graphics.Blit(source, destination, CAMat);
            }
            else 
            {
                Graphics.Blit(source, destination);
            }
        }
        
        private void UpdateShaderParams()
        {
            CAMat.SetFloat(PWShaderPropertyIDs.EffectActive_ID, Active);
            CAMat.SetFloat(PWShaderPropertyIDs.ROffset_ID, R_Offset);
            CAMat.SetFloat(PWShaderPropertyIDs.GOffset_ID, G_Offset);
            CAMat.SetFloat(PWShaderPropertyIDs.BOffset_ID, B_Offset);
            CAMat.SetVector(PWShaderPropertyIDs.ROffsetDir_ID, R_OffsetDir);
            CAMat.SetVector(PWShaderPropertyIDs.GOffsetDir_ID, G_OffsetDir);
            CAMat.SetVector(PWShaderPropertyIDs.BOffsetDir_ID, B_OffsetDir);
        }
    }
}