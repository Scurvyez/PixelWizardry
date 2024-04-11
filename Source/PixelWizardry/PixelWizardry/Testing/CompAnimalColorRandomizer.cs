using Verse;
using UnityEngine;

namespace PixelWizardry
{
    public class CompProperties_AnimalColorRandomizer : CompProperties
    {
        public FloatRange rRangeOne;
        public FloatRange gRangeOne;
        public FloatRange bRangeOne;

        public FloatRange rRangeTwo;
        public FloatRange gRangeTwo;
        public FloatRange bRangeTwo;
     
        public CompProperties_AnimalColorRandomizer()
        {
            compClass = typeof(CompAnimalColorRandomizer);
        }
    }

    public class CompAnimalColorRandomizer : ThingComp
    {
        public CompProperties_AnimalColorRandomizer Props => (CompProperties_AnimalColorRandomizer)props;

        public Color newColor = new Color();
        public Color newColorTwo = new Color();

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
            if (!respawningAfterLoad && parent is Pawn pawn)
            {
                newColor = new Color(Props.rRangeOne.RandomInRange, Props.gRangeOne.RandomInRange, Props.bRangeOne.RandomInRange, 2f);
                newColorTwo = new Color(Props.rRangeTwo.RandomInRange, Props.gRangeTwo.RandomInRange, Props.bRangeTwo.RandomInRange, 2f);
                pawn.Drawer.renderer.SetAllGraphicsDirty();
            }
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref newColor, "newColor");
            Scribe_Values.Look(ref newColorTwo, "newColorTwo");
        }
    }
}
