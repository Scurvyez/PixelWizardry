using Verse;

namespace PixelWizardry
{
    public class PawnRenderNode_AnimalRandomizedGraphics : PawnRenderNode_AnimalPart
    {
        public PawnRenderNode_AnimalRandomizedGraphics(Pawn pawn, PawnRenderNodeProperties props, PawnRenderTree tree) : base(pawn, props, tree)
        {
            // don't need anything in our ctor
        }

        public override Graphic GraphicFor(Pawn pawn)
        {
            if (pawn.TryGetComp(out CompAnimalColorRandomizer comp))
            {
                Graphic graphic = pawn.ageTracker.CurKindLifeStage.bodyGraphicData.Graphic;
                return GraphicDatabase.Get<Graphic_Multi>(graphic.path, ShaderDatabase.CutoutComplex, graphic.drawSize, comp.newColor, comp.newColorTwo);
            }
            return base.GraphicFor(pawn);
        }
    }
}
