using LudeonTK;
using RimWorld;
using Verse;

namespace PixelWizardry
{
    public class PWDebugActionsMisc
    {
        [DebugAction("PW General", null, false, false, false, false, 0, false, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void SpawnMote()
        {
            Map curMap = Find.CurrentMap;
            IntVec3 spawnCell = UI.MouseCell();
            if (curMap != null && spawnCell.InBounds(curMap))
            {
                MoteMaker.MakeStaticMote(spawnCell, curMap, PWDefOf.PW_MoteTestDef, 1f);
            }
        }
    }
}
