using HarmonyLib;
using UnityEngine;
using Verse;

namespace PixelWizardry
{
    [StaticConstructorOnStartup]
    public static class PixelWizardryMain
    {
        public static ComputeShader PathHeatMapShader;
        public static int PathHeatMapShaderKernelIndex;
        public static RenderTexture HeatmapTexture;
        public static Material HeatmapMaterial;
        
        public const int HeatmapResolution = 512;
        
        static PixelWizardryMain()
        {
            PWLog.Message("[1.5 Update | Older versions will no longer be maintained.]");

            Harmony harmony = new ("com.pixelwizardry");
            harmony.PatchAll();
            
            PathHeatMapShader = PWContentDatabase.PathHeatmap;
            PathHeatMapShaderKernelIndex = PathHeatMapShader.FindKernel("CSMain");
            PWLog.Message($"Testing Shader: {PathHeatMapShader != null}, Kernel: {PathHeatMapShaderKernelIndex}");
            
            InitializeHeatmapTexture();
            InitializeHeatmapMaterial();
        }
        
        private static void InitializeHeatmapTexture()
        {
            HeatmapTexture = new RenderTexture(HeatmapResolution, HeatmapResolution, 0, RenderTextureFormat.ARGBFloat);
            HeatmapTexture.enableRandomWrite = true;
            HeatmapTexture.Create();
        }

        private static void InitializeHeatmapMaterial()
        {
            HeatmapMaterial = new Material(PWContentDatabase.HeatmapEffect);
            HeatmapMaterial.mainTexture = HeatmapTexture;
        }
    }
}
