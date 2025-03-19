using UnityEngine;

namespace PixelWizardry
{
    public static class PWShaderPropertyIDs
    {
        private static readonly string HName = "_H";
        private static readonly string SName = "_S";
        private static readonly string VName = "_V";

        public static int H = Shader.PropertyToID(HName);
        public static int S = Shader.PropertyToID(SName);
        public static int V = Shader.PropertyToID(VName);
    }
}