using RimWorld;

namespace PixelWizardry
{
    [DefOf]
    public static class PWShaderTypeDefOf
    {
        public static PWShaderTypeDef PWBlendHardLight;
        public static PWShaderTypeDef PWBlendLinearBurn;
        public static PWShaderTypeDef PWBlendLinearDodge;
        public static PWShaderTypeDef PWBlendMultiply;
        public static PWShaderTypeDef PWBlendOverlay;
        public static PWShaderTypeDef PWBlendScreen;
        public static PWShaderTypeDef PWBlendSoftLight;
        public static PWShaderTypeDef PWBlendSubtract;
        public static PWShaderTypeDef PWBlendTransparentRGBToBlack;
        public static PWShaderTypeDef PWBlendTransparentRGBToGrayscale;
        public static PWShaderTypeDef PWBlendTransparentSepiaTone;
        public static PWShaderTypeDef PWBlendVividLight;
        public static PWShaderTypeDef PWCutout_LUT;
        public static PWShaderTypeDef PWRGBToHSV;
        
        static PWShaderTypeDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(PWShaderTypeDefOf));
        }
    }
}