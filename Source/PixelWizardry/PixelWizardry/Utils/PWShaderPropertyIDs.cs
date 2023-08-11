using UnityEngine;

namespace PixelWizardry
{
    public static class PWShaderPropertyIDs
    {
        private static readonly string PulseSpeedName = "_PulseSpeed";
        private static readonly string PulseAmplitudeName = "_PulseAmplitude";
        private static readonly string OscillationSpeedName = "_OscillationSpeed";
        private static readonly string HueLerpName = "_HueLerp";
        private static readonly string SaturationLerpName = "_SaturationLerp";
        private static readonly string ValueLerpName = "_ValueLerp";

        public static int PulseSpeed = Shader.PropertyToID(PulseSpeedName);
        public static int PulseAmplitude = Shader.PropertyToID(PulseAmplitudeName);
        public static int OscillationSpeed = Shader.PropertyToID(OscillationSpeedName);
        public static int HueLerp = Shader.PropertyToID(HueLerpName);
        public static int SaturationLerp = Shader.PropertyToID(SaturationLerpName);
        public static int ValueLerp = Shader.PropertyToID(ValueLerpName);
    }
}
