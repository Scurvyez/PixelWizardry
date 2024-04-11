using RimWorld;
using Verse;

namespace PixelWizardry
{
    [DefOf]
    public class PWDefOf
    {
        public static ThingDef PW_MoteTestDef;
        public static PawnKindDef PW_TestAnimal;

        static PWDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(PWDefOf));
        }
    }
}
