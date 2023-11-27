using RimWorld;
using Verse;
using UnityEngine;

namespace PixelWizardry
{
    /*
    public class MapComp_UpdatePositionTrackingShader : MapComponent
    {
        FullScreenEffects fullScreenEffects = FullScreenEffects.instance;
        private IntVec3 trackedPosition;

        public MapComp_UpdatePositionTrackingShader(Map map) : base(map) { }

        public override void MapComponentTick()
        {
            base.MapComponentTick();

            if (PWModSettings.EnableWeirdEffects && !PWModSettings.EnableColorBlindModes)
            {
                fullScreenEffects.material.SetFloat("_UseColorBlindModes", 0f);
                fullScreenEffects.material.SetFloat("_UseWeirdEffects", 1f);

                // Iterate over all things on the map
                foreach (Thing thing in map.listerThings.AllThings)
                {
                    // Check if the thing is an animal (you can replace ThingWithComps with the actual type of your animal)
                    if (thing is ThingWithComps animal)
                    {
                        // Check if this is the specific animal you want to track (you can replace with your own condition)
                        if (animal.def == ThingDefOf.Cow)
                        {
                            // Update the tracked position
                            trackedPosition = animal.Position;

                            fullScreenEffects.material.SetFloat("_UseColorBlindModes", 0f);
                            fullScreenEffects.material.SetFloat("_UseWeirdEffects", 1f);
                            fullScreenEffects.material.SetVector("_TrackedPosition", new Vector4(trackedPosition.x, trackedPosition.y, trackedPosition.z, 1));
                        }
                    }
                }
            }
        }
    }
    */
}
