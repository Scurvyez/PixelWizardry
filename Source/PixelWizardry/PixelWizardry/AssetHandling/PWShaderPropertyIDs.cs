using UnityEngine;

namespace PixelWizardry
{
    public static class PWShaderPropertyIDs
    {
        private static readonly string H_Name = "_H";
        private static readonly string S_Name = "_S";
        private static readonly string V_Name = "_V";
        private static readonly string LUTTex_Name = "_LUTTex";
        private static readonly string Colors_Name = "_Colors";
        private static readonly string ColorCount_Name = "_ColorCount";
        private static readonly string BlendStrength_Name = "_BlendStrength";
        private static readonly string ROffset_Name = "_ROffset";
        private static readonly string GOffset_Name = "_GOffset";
        private static readonly string BOffset_Name = "_BOffset";
        private static readonly string ROffsetDir_Name = "_ROffsetDir";
        private static readonly string GOffsetDir_Name = "_GOffsetDir";
        private static readonly string BOffsetDir_Name = "_BOffsetDir";
        private static readonly string EffectActive_Name = "_EffectActive";
        private static readonly string EffectStrength_Name = "_EffectStrength";
        
        public static readonly int H_ID = Shader.PropertyToID(H_Name);
        public static readonly int S_ID = Shader.PropertyToID(S_Name);
        public static readonly int V_ID = Shader.PropertyToID(V_Name);
        public static readonly int LUTTex_ID = Shader.PropertyToID(LUTTex_Name);
        public static readonly int Colors_ID = Shader.PropertyToID(Colors_Name);
        public static readonly int ColorCount_ID = Shader.PropertyToID(ColorCount_Name);
        public static readonly int BlendStrength_ID = Shader.PropertyToID(BlendStrength_Name);
        public static readonly int ROffset_ID = Shader.PropertyToID(ROffset_Name);
        public static readonly int GOffset_ID = Shader.PropertyToID(GOffset_Name);
        public static readonly int BOffset_ID = Shader.PropertyToID(BOffset_Name);
        public static readonly int ROffsetDir_ID = Shader.PropertyToID(ROffsetDir_Name);
        public static readonly int GOffsetDir_ID = Shader.PropertyToID(GOffsetDir_Name);
        public static readonly int BOffsetDir_ID = Shader.PropertyToID(BOffsetDir_Name);
        public static readonly int EffectActive_ID = Shader.PropertyToID(EffectActive_Name);
        public static readonly int EffectStrength_ID = Shader.PropertyToID(EffectStrength_Name);
    }
}