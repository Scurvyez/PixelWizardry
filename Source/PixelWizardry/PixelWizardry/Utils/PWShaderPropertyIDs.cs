using UnityEngine;

namespace PixelWizardry
{
    public static class PWShaderPropertyIDs
    {
        private static readonly string PulseSpeedName = "_PulseSpeed";
        private static readonly string PulseAmplitudeName = "_PulseAmplitude";

        public static int PulseSpeed = Shader.PropertyToID(PulseSpeedName);
        public static int PulseAmplitude = Shader.PropertyToID(PulseAmplitudeName);
    }
}
