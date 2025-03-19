using Verse;

namespace PixelWizardry
{
    public class PWSettings : ModSettings
    {
        private static PWSettings _instance;
        
        public PWSettings() => _instance = this;
        public static bool EnableHSVAdjustment => _instance._EnableHSVAdjustment;
        public static float HAmount => _instance._HAmount;
        public static float SAmount => _instance._SAmount;
        public static float VAmount => _instance._VAmount;
        
        public bool _EnableHSVAdjustment = false;
        public float _HAmount = 1f;
        public float _SAmount = 1f;
        public float _VAmount = 1f;
        
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref _EnableHSVAdjustment, "_EnableHSVAdjustment", false);
            Scribe_Values.Look(ref _HAmount, "_HAmount", 1f);
            Scribe_Values.Look(ref _SAmount, "_SAmount", 1f);
            Scribe_Values.Look(ref _VAmount, "_VAmount", 1f);
        }
    }
}