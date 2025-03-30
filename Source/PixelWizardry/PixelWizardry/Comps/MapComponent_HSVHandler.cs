using Verse;

namespace PixelWizardry.Comps
{
    public class MapComponent_HSVHandler : MapComponent
    {
        private readonly FullScreen_HSV _fSE;
        
        public MapComponent_HSVHandler(Map map) : base(map)
        {
            _fSE = FullScreen_HSV.Instance;
        }
        
        public override void MapComponentUpdate()
        {
            base.MapComponentUpdate();

            if (!PWSettings.EnableHSVAdjustment || _fSE == null) return;
            _fSE.HSVMat.SetFloat(PWShaderPropertyIDs.H_ID, PWSettings.HAmount);
            _fSE.HSVMat.SetFloat(PWShaderPropertyIDs.S_ID, PWSettings.SAmount);
            _fSE.HSVMat.SetFloat(PWShaderPropertyIDs.V_ID, PWSettings.VAmount);
        }
    }
}