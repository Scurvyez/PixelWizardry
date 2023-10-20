using UnityEngine;
using Verse;

namespace PixelWizardry
{
    /*
    [StaticConstructorOnStartup]
    public class SectionLayer_RadialGradialChanges : SectionLayer
    {
        private static readonly Texture2D RadialGradientChange = ContentFinder<Texture2D>.Get("Map/Effects/RadialGradientChange");

        private Material mapReactiveMat;
        private MaterialPropertyBlock propertyBlock;
        private int lastDrawTick = -10 * GenTicks.TicksPerRealSecond; // Initialize to -10 seconds

        public SectionLayer_RadialGradialChanges(Section section) : base(section)
        {
            propertyBlock = new MaterialPropertyBlock();
            relevantChangeTypes = MapMeshFlag.Terrain;

            mapReactiveMat = new Material(PWContentDatabase.TransparentRGBToGrayscale);
            mapReactiveMat.SetTexture("_MainTex", RadialGradientChange);
        }

        public override void Regenerate()
        {
            float colorValue = Mathf.PingPong(Find.TickManager.TicksGame, GenTicks.TicksPerRealSecond) / (float)GenTicks.TicksPerRealSecond;
            propertyBlock.SetColor("_Color", new Color(colorValue, colorValue, colorValue, 1.0f));
        }

        public override void DrawLayer()
        {
            // Check if enough ticks have passed since the last draw
            if (Find.TickManager.TicksGame - lastDrawTick >= 10 * GenTicks.TicksPerRealSecond)
            {
                // Generate a random position on the map
                IntVec3 randomCell = CellFinder.RandomCell(Map);
                Vector3 position = randomCell.ToVector3();

                // Draw the bioluminescent mesh at the position of the random cell
                Graphics.DrawMesh(MeshPool.plane10, position, Quaternion.identity, mapReactiveMat, 0, null, 0, propertyBlock);

                // Update the last draw tick to the current tick
                lastDrawTick = Find.TickManager.TicksGame;
            }
        }
    }
    */
}
