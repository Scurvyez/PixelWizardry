using Verse;

namespace PixelWizardry.Comps
{
    /// <summary>
    /// STUB - an example comp to access and control the fullscreen
    /// chromatic aberration post-processing effect.
    /// </summary>
    public class MapComponent_CAHandler : MapComponent
    {
        private readonly FullScreen_CA _fSE;
        
        public MapComponent_CAHandler(Map map) : base(map)
        {
            _fSE = FullScreen_CA.Instance;
        }
    }
}