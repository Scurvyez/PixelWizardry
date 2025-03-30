using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Verse;

namespace PixelWizardry
{
    [StaticConstructorOnStartup]
    public static class PWContentDatabase
    {
        private static AssetBundle _bundleInt;
        private static Dictionary<string, Shader> _lookupShaders;
        private const string _rootPathUnlit = "Assets/Shaders/Unlit";
        
        // thing specific (ideally lol)
        public static readonly Shader BlendChromaticAberration = LoadShader(Path.Combine(_rootPathUnlit, "BlendChromaticAberration.shader"));
        public static readonly Shader BlendHardLight = LoadShader(Path.Combine(_rootPathUnlit, "BlendHardLight.shader"));
        public static readonly Shader BlendLinearBurn = LoadShader(Path.Combine(_rootPathUnlit, "BlendLinearBurn.shader"));
        public static readonly Shader BlendLinearDodge = LoadShader(Path.Combine(_rootPathUnlit, "BlendLinearDodge.shader"));
        public static readonly Shader BlendMultiply = LoadShader(Path.Combine(_rootPathUnlit, "BlendMultiply.shader"));
        public static readonly Shader BlendOverlay = LoadShader(Path.Combine(_rootPathUnlit, "BlendOverlay.shader"));
        public static readonly Shader BlendScreen = LoadShader(Path.Combine(_rootPathUnlit, "BlendScreen.shader"));
        public static readonly Shader BlendSoftLight = LoadShader(Path.Combine(_rootPathUnlit, "BlendSoftLight.shader"));
        public static readonly Shader BlendSubtract = LoadShader(Path.Combine(_rootPathUnlit, "BlendSubtract.shader"));
        public static readonly Shader BlendTransparentRGBToBlack = LoadShader(Path.Combine(_rootPathUnlit, "BlendTransparentRGBToBlack.shader"));
        public static readonly Shader BlendTransparentRGBToGrayscale = LoadShader(Path.Combine(_rootPathUnlit, "BlendTransparentRGBToGrayscale.shader"));
        public static readonly Shader BlendTransparentSepiaTone = LoadShader(Path.Combine(_rootPathUnlit, "BlendTransparentSepiaTone.shader"));
        public static readonly Shader BlendVividLight = LoadShader(Path.Combine(_rootPathUnlit, "BlendVividLight.shader"));
        public static readonly Shader Cutout_LUT = LoadShader(Path.Combine(_rootPathUnlit, "Cutout_LUT.shader"));
        public static readonly Shader RGBToHSV = LoadShader(Path.Combine(_rootPathUnlit, "RGBToHSV.shader"));
        
        // fullscreen effects
        public static readonly Shader ScreenChromaticAberration = LoadShader(Path.Combine(_rootPathUnlit, "ScreenChromaticAberration.shader"));
        public static readonly Shader ScreenHSV = LoadShader(Path.Combine(_rootPathUnlit, "ScreenHSV.shader"));
        
        // testing textures
        public static readonly Texture2D Noise_092 = ContentFinder<Texture2D>.Get("PixelWizardry/Noise_092");
        
        public static AssetBundle PWBundle
        {
            get
            {
                if (_bundleInt != null) return _bundleInt;
                try
                {
                    _bundleInt = PWMod.PW_Mod.MainBundle;
                    if (_bundleInt == null)
                    {
                        throw new Exception("MainBundle is null.");
                    }
                    return _bundleInt;
                }
                catch (Exception ex)
                {
                    PWLog.Warning($"Failed to load AssetBundle. " +
                                  $"Exception: {ex.Message}");
                    return null;
                }
            }
        }
        
        private static Shader LoadShader(string shaderName)
        {
            _lookupShaders ??= new Dictionary<string, Shader>();
            try
            {
                if (!_lookupShaders.ContainsKey(shaderName))
                {
                    _lookupShaders[shaderName] = PWBundle.LoadAsset<Shader>(shaderName);
                }
                
                Shader shader = _lookupShaders[shaderName];
                if (shader == null)
                {
                    throw new Exception($"Shader '{shaderName}' " +
                                        $"is null after loading.");
                }
                return shader;
            }
            catch (Exception ex)
            {
                PWLog.Warning($"Failed to load shader: {shaderName}. " +
                              $"Exception: {ex.Message}");
                return ShaderDatabase.DefaultShader;
            }
        }
    }
}