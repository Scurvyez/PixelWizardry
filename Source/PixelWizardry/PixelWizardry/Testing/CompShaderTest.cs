using RimWorld;
using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class CompProperties_ShaderTest : CompProperties
    {
        public ThingDef moteDef = null;
        public Color moteColor = Color.white;

        public CompProperties_ShaderTest()
        {
            compClass = typeof(CompShaderTest);
        }
    }

    public class CompShaderTest : ThingComp
    {
        private Mote mote;

        public CompProperties_ShaderTest Props => (CompProperties_ShaderTest)props;

        public override void CompTick()
        {
            base.CompTick();
            if (parent.Spawned)
            {
                if (mote == null || mote.Destroyed)
                {
                    mote = MoteMaker.MakeAttachedOverlay(parent, Props.moteDef, Vector3.zero);
                }
                mote.instanceColor = Props.moteColor;
                mote.Maintain();
            }
        }
    }
}
