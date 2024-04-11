using RimWorld;
using UnityEngine;
using Verse;

namespace PixelWizardry
{
    public class CompProperties_AnimalColorBasedStats : CompProperties
    {
        public CompProperties_AnimalColorBasedStats()
        {
            compClass = typeof(CompAnimalColorBasedStats);
        }
    }

    public class CompAnimalColorBasedStats : ThingComp
    {
        public CompProperties_AnimalColorBasedStats Props => (CompProperties_AnimalColorBasedStats)props;

        public override float GetStatOffset(StatDef stat)
        {
            if (parent.TryGetComp(out CompAnimalColorRandomizer comp))
            {
                Color color = comp.newColor;
                float maxValue = CalculateMaxValue(color);

                return maxValue switch
                {
                    { } when maxValue == color.r => 7.0f, 
                    { } when maxValue == color.g => 5.0f,
                    { } when maxValue == color.b => 3.0f,
                    _ => 0f
                };
            }
            else
            {
                return 0f;
            }
        }

        private float CalculateMaxValue(Color color)
        {
            float total = color.r + color.g + color.b;
            float maxProportionalDifference = Mathf.Max(Mathf.Abs(color.r - color.g), Mathf.Abs(color.g - color.b), Mathf.Abs(color.b - color.r));
            return total - maxProportionalDifference;
        }
    }
}
