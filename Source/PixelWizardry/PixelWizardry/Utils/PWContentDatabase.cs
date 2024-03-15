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
        public static readonly Shader ScreenPositionEffects = LoadShader(Path.Combine("Assets", "ScreenPositionEffects.shader"));
        public static readonly Shader TEST = LoadShader(Path.Combine("Assets", "TEST.shader"));

        public static AssetBundle PWBundle
        {
            get
            {
                if (bundleInt == null)
                {
                    bundleInt = PixelWizardryMod.mod.MainBundle;
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
                //Log.Message("[<color=#4494E3FF>Pixel Wizardry</color>] Loaded shaders: " + lookupShaders.Count );
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
