using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Verse;

namespace PixelWizardry
{
    [StaticConstructorOnStartup]
    public static class PWContentDatabase
    {
        private static AssetBundle bundleInt;
        private static Dictionary<string, Shader> lookupShaders;
        private static Dictionary<string, ComputeShader> lookupComputeShaders;
        
        public static readonly Shader BlendLinearDodge = LoadShader(Path.Combine("Assets", "BlendLinearDodge.shader"));
        public static readonly Shader BlendSubtract = LoadShader(Path.Combine("Assets", "BlendSubtract.shader"));
        public static readonly Shader BlendScreen = LoadShader(Path.Combine("Assets", "BlendScreen.shader"));
        public static readonly Shader BlendMultiply = LoadShader(Path.Combine("Assets", "BlendMultiply.shader"));
        public static readonly Shader BlendLinearBurn = LoadShader(Path.Combine("Assets", "BlendLinearBurn.shader"));
        public static readonly Shader BlendTransparentRGBToBlack = LoadShader(Path.Combine("Assets", "BlendTransparentRGBToBlack.shader"));
        public static readonly Shader BlendTransparentRGBToGrayscale = LoadShader(Path.Combine("Assets", "BlendTransparentRGBToGrayscale.shader"));
        public static readonly Shader RGBToHSV = LoadShader(Path.Combine("Assets", "RGBToHSV.shader"));
        public static readonly Shader ScreenColorBlindness = LoadShader(Path.Combine("Assets", "ScreenColorBlindness.shader"));
        public static readonly Shader ScreenHSV = LoadShader(Path.Combine("Assets", "ScreenHSV.shader"));
        public static readonly Shader HeatmapEffect = LoadShader(Path.Combine("Assets", "HeatMapEffect.shader"));
        
        public static readonly ComputeShader PathHeatmap = LoadComputeShader(Path.Combine("Assets", "PathHeatMap.compute"));
        public static readonly ComputeShader TESTING = LoadComputeShader(Path.Combine("Assets", "TESTING.compute"));
        
        public static AssetBundle PWBundle
        {
            get
            {
                if (bundleInt != null) return bundleInt;
                bundleInt = PixelWizardryMod.mod.MainBundle;
                PWLog.Message("bundleInt: " + bundleInt.name);
                return bundleInt;
            }
        }
        
        private static Shader LoadShader(string shaderName)
        {
            lookupShaders ??= new Dictionary<string, Shader>();
            
            if (!lookupShaders.ContainsKey(shaderName))
            {
                lookupShaders[shaderName] = PWBundle.LoadAsset<Shader>(shaderName);
            }
            
            Shader shader = lookupShaders[shaderName];
            if (shader == null)
            {
                PWLog.Warning($"Failed to load shader: {shaderName}");
                return ShaderDatabase.DefaultShader;
            }
            
            PWLog.Message($"Successfully loaded shader: {shaderName}");
            return shader;
        }

        public static ComputeShader LoadComputeShader(string computeShaderName)
        {
            lookupComputeShaders ??= new Dictionary<string, ComputeShader>();

            if (!lookupComputeShaders.ContainsKey(computeShaderName))
            {
                lookupComputeShaders[computeShaderName] = PWBundle.LoadAsset<ComputeShader>(computeShaderName);
            }
            
            ComputeShader computeShader = lookupComputeShaders[computeShaderName];
            if (computeShader == null)
            {
                PWLog.Warning($"Failed to load compute shader: {computeShaderName}");
                return null;
            }

            PWLog.Message($"Successfully loaded compute shader: {computeShaderName}");
            return computeShader;
        }
    }
}