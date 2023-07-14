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
        private static Dictionary<string, Material> lookupMaterials;
        public static readonly Shader LinearDodge = LoadShader(Path.Combine("Assets", "LinearDodge.shader"));
        public static readonly Shader Subtract = LoadShader(Path.Combine("Assets", "Subtract.shader"));
        public static readonly Shader Screen = LoadShader(Path.Combine("Assets", "Screen.shader"));
        public static readonly Shader Multiply = LoadShader(Path.Combine("Assets", "Multiply.shader"));
        public static readonly Shader LinearBurn = LoadShader(Path.Combine("Assets", "LinearBurn.shader"));
        public static readonly Shader LinearDodgePulse = LoadShader(Path.Combine("Assets", "LinearDodgePulse.shader"));
        public static readonly Shader SubtractPulse = LoadShader(Path.Combine("Assets", "SubtractPulse.shader"));
        public static readonly Shader TransparentRGBToBlack = LoadShader(Path.Combine("Assets", "TransparentRGBToBlack.shader"));
        public static readonly Shader TransparentRGBToBlackPulse = LoadShader(Path.Combine("Assets", "TransparentRGBToBlackPulse.shader"));
        public static readonly Shader ScreenPulse = LoadShader(Path.Combine("Assets", "ScreenPulse.shader"));
        public static readonly Shader TransparentPulse = LoadShader(Path.Combine("Assets", "TransparentPulse.shader"));
        
        public static AssetBundle PWBundle
        {
            get
            {
                if (bundleInt == null)
                {
                    bundleInt = PWMod.mod.MainBundle;
                    //Log.Message("[<color=#4494E3FF>Pixel Wizardry</color>] <color=#e36c45FF>bundleInt:</color> " + bundleInt.name);
                }
                return bundleInt;
            }
        }

        public static Shader LoadShader(string shaderName)
        {
            if (lookupShaders == null)
            {
                lookupShaders = new Dictionary<string, Shader>();
            }
            if (!lookupShaders.ContainsKey(shaderName))
            {
                //Log.Message("[<color=#4494E3FF>Pixel Wizardry</color>] lookupShaders: " + lookupShaders.ToList().Count);
                lookupShaders[shaderName] = PWBundle.LoadAsset<Shader>(shaderName);
            }
            Shader shader = lookupShaders[shaderName];
            if (shader == null)
            {
                Log.Warning("[<color=#4494E3FF>Pixel Wizardry</color>] <color=#e36c45FF>Could not load shader:</color> " + shaderName);
                return ShaderDatabase.DefaultShader;
            }
            if (shader != null)
            {
                Log.Message("[<color=#4494E3FF>Pixel Wizardry</color>] Loaded shader: " + shaderName);
            }
            return shader;
        }

        public static Material LoadMaterial(string materialName)
        {
            if (lookupMaterials == null)
            {
                lookupMaterials = new Dictionary<string, Material>();
            }
            if (!lookupMaterials.ContainsKey(materialName))
            {
                lookupMaterials[materialName] = PWBundle.LoadAsset<Material>(materialName);
            }
            Material material = lookupMaterials[materialName];
            if (material == null)
            {
                Log.Warning("[<color=#4494E3FF>Pixel Wizardry</color>] <color=#e36c45FF>Could not load material:</color> " + materialName);
                return BaseContent.BadMat;
            }
            return material;
        }
    }
}
