using System.Collections.Generic;
using Verse;

namespace PixelWizardry
{
    public class CompProperties_ExtraGraphics : CompProperties
    {
        public List<GraphicData> graphics = null;

        public CompProperties_ExtraGraphics()
        {
            compClass = typeof(Comp_ExtraGraphics);
        }
    }
}
